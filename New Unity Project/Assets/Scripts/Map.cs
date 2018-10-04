using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour {

    public GameObject[] randomItem;
    public Transform Pos;
    public static Map Joker;
    public Slider blueHpSlider;
    public Slider redHpSlider;

    private int count=0;
    private Animator animator;
    private float timer = 0f;
    private int time = 0;
    private int hpRed;
    private int hpBlue;
    private int maxHp=100;

	void Awake () {
        int i = 2;// Random.Range(0, 4);
        GameObject.Instantiate(randomItem[i], Pos.position, Quaternion.identity);
        animator = GetComponentInChildren<Animator>();
        Joker = this;

        hpBlue = maxHp;
        hpRed = maxHp;
	}
	
	void Update () {
        timer += Time.deltaTime;
        if (timer > 10)
        {
            int i = Random.Range(0, 4);
            GameObject.Instantiate(randomItem[i], Pos.position, Quaternion.identity);
            time++; timer = 0;
            if (time >= 3)
            {
                time = 0; count++;
                if (count >= 4) Judge();
                else animator.SetTrigger("AllWallMove"+count);//3.7,6.4;   2.7,5;  
            }
        }
	}

    public void ChangeHp(bool isRed,int n)
    {
        if (isRed)
        {
            hpRed = n;
            redHpSlider.value = (float)hpRed/maxHp;
        }
        else
        {
            hpBlue = n;
            blueHpSlider.value = (float)hpBlue/maxHp;
        }
    }

    void Judge()
    {
        if (hpRed > hpBlue)
        {
            GameManager.Instance.GameOver(true);
        }
        else
        {
            if (hpRed < hpBlue) GameManager.Instance.GameOver(false);
            else GameManager.Instance.Tie();
        }
    }
}
