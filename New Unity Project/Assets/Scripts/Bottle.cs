using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour {

    public GameObject bullet;
    public Transform firePos;
    public Transform tmpPos;
    public bool isRed=true;


    private float strength = 200f;
    private int hp;
    private int maxHp = 100;
    private Animator animator;

	// Use this for initialization
	void Awake () {
        hp = maxHp;
        animator = GetComponentInChildren<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        if (  (isRed && Input.GetKeyDown(KeyCode.UpArrow)) ||  (!isRed && Input.GetKeyDown(KeyCode.Q))  )
        {
            GameObject.Instantiate(bullet, firePos.position, firePos.rotation);
            Vector2 direction = tmpPos.position - firePos.position;
            this.GetComponent<Rigidbody2D>().AddForceAtPosition(direction * strength, firePos.position);
        }

    }
    public void  TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            animator.SetTrigger("Dead");
            Destroy(this.gameObject, 0.6f);
            GameManager.Instance.GameOver(!isRed);
        }
    }
}
