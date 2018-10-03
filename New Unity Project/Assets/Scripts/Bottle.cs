using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour {

    public GameObject bullet;
    public Transform firePos;
    public Transform tmpPos;
    public bool isRed=true;
    public AudioClip underAttackAudio;
    public AudioClip impactAudio;
    public AudioClip fireAudio;

    private AudioSource happyLearn;
    private float strength = 200f;
    private int hp;
    private int maxHp = 100;
    private Animator animator;

	// Use this for initialization
	void Awake () {
        hp = maxHp;
        animator = GetComponentInChildren<Animator>();
        happyLearn = GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt("music") == 0)
            happyLearn.enabled = false;
        else
        {
            happyLearn.enabled = true;
            happyLearn.volume = PlayerPrefs.GetFloat("volume");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (happyLearn.enabled) happyLearn.PlayOneShot(impactAudio);
    }

    // Update is called once per frame
    void Update()
    {
        if (  (isRed && Input.GetKeyDown(KeyCode.UpArrow)) ||  (!isRed && Input.GetKeyDown(KeyCode.Q))  )
        {
            if (happyLearn.enabled) happyLearn.PlayOneShot(fireAudio);
            GameObject.Instantiate(bullet, firePos.position, firePos.rotation);
            Vector2 direction = tmpPos.position - firePos.position;
            this.GetComponent<Rigidbody2D>().AddForceAtPosition(direction * strength, firePos.position);
        }

    }
    public void  TakeDamage(int damage)
    {
        hp -= damage;
        Map.Joker.ChangeHp(isRed, damage);
        if (happyLearn.enabled) happyLearn.PlayOneShot(underAttackAudio);
        if (hp <= 0)
        {
            animator.SetTrigger("Dead");
            if (happyLearn.enabled) happyLearn.Play();
            Destroy(this.gameObject, 2f);
            GameManager.Instance.GameOver(!isRed);
        }
    }
}
