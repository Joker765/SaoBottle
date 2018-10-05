using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour {

    public GameObject bullet;
    public GameObject bulletBounce;
    public GameObject bulletElectric;
    public GameObject bulletSplit;
    public Transform firePos;
    public Transform tmpPos;
    public Transform rayPos;
    public string Enemy;
    public bool isRed=true;
   
    public AudioClip underAttackAudio;
    public AudioClip impactAudio;
    public AudioClip fireAudio;
    public AudioClip electricAudio;

    private int electricFireTime=0;
    private bool buff = false;
    private int bulletKind = 0;
    private AudioSource happyLearn;
    private float strength = 200f;
    private int hp;
    private Animator animator;

	void Awake () {
        hp = 100;
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
        if (Input.GetMouseButtonDown(0))
        {
            //Get the mouse position on the screen and send a raycast into the game world from that position.
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            //If something was hit, the RaycastHit2D.collider will not be null.
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.tag);
            }
        }
        if (  (isRed && Input.GetKeyDown(KeyCode.UpArrow)) ||  (!isRed && Input.GetKeyDown(KeyCode.Q))  )
        {
            if (happyLearn.enabled) happyLearn.PlayOneShot(fireAudio);
            Fire();
            Vector2 direction = tmpPos.position - firePos.position;
            this.GetComponent<Rigidbody2D>().AddForceAtPosition(direction * strength, firePos.position);
        }
    }

    private void Fire()
    {
        if (buff)
        {
            buff = false;
            switch (bulletKind)
            {
                case 1: GameObject.Instantiate(bulletBounce, firePos.position, firePos.rotation); break;
                case 2:
                    electricFireTime++;
                    if (electricFireTime < 5) buff = true;
                    else electricFireTime = 0;
                    GameObject.Instantiate(bulletElectric, firePos.position, firePos.rotation);
                    if (happyLearn.enabled) happyLearn.PlayOneShot(electricAudio);
                    Electric();
                    break;
                case 3: GameObject.Instantiate(bulletSplit, firePos.position, firePos.rotation); break;
            }
        }
        else  GameObject.Instantiate(bullet, firePos.position, firePos.rotation);
    }

    void Electric()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayPos.position, rayPos.right,Mathf.Infinity,1<<LayerMask.NameToLayer("Bottle"));

        if (hit.collider!=null)
        {
            if (hit.collider.GetComponent<Bottle>())
                hit.collider.GetComponent<Bottle>().TakeDamage(40);
            else hit.collider.GetComponent<BottleAI>().TakeDamage(40);
        }
}


    public void KindOfBullet(string s)
    {
        switch (s)
        {
            case "Bounce": buff = true;  bulletKind = 1;   break;
            case "Electric":  buff = true; bulletKind=2;     break;
            case "Split":      buff = true;  bulletKind=3;    break;
            case "AddHp": AddHp(); break;
        }
    }

     public void AddHp()
    {
        hp += 70;
        if (hp > 100) hp = 100;
        Map.Joker.ChangeHp(isRed,hp);
    }

    public void  TakeDamage(int damage)
    {
        hp -= damage;
        Map.Joker.ChangeHp(isRed, hp);
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
