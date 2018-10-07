using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string Enemy;
    public string myName="bullet";
    public GameObject bullet;

    private float timer = 0f;
    private Vector2 direction;
    private int damage = 30;
    private float speed = 8;

    private void Start()
    {
        direction= transform.right; // red axis in world space
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (myName == "Electric" && timer > 0.05) Die();else 
        if (myName == "Bounce" && timer > 8) Die();
        transform.Translate(direction * speed * Time.deltaTime,Space.World); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (myName == "bullet")
        {
            if (other.tag == "Wall") Die();
            else if (other.tag == Enemy)
            {
                if (other.GetComponent<Bottle>())
                    other.GetComponent<Bottle>().TakeDamage(damage);
                else other.GetComponent<BottleAI>().TakeDamage(damage);
                Die();
            }
        }
        else if (myName == "Bounce")
        {
            if (other.tag == Enemy)
            {
                if (other.GetComponent<Bottle>())
                    other.GetComponent<Bottle>().TakeDamage(damage);
                else other.GetComponent<BottleAI>().TakeDamage(damage);
                Die();
            }
            else if (other.tag == "Wall")
            {
                if (other.name == "HorizontalUp" || other.name == "HorizontalDown")
                    direction.y = -direction.y;
                else direction.x = -direction.x;
            }
        }
        else if (myName == "Split")
        {
            if (other.tag == "Wall") { Die(); Split(); }
            else if (other.tag == Enemy)
            {
                if(other.GetComponent<Bottle>())
                    other.GetComponent<Bottle>().TakeDamage(damage);
                else other.GetComponent<BottleAI>().TakeDamage(damage);
                Die(); Split();
            }
        }
        else if (myName == "Electric")
        {
            if (other.tag == Enemy)
                if (other.GetComponent<Bottle>())
                    other.GetComponent<Bottle>().TakeDamage(damage);
                else other.GetComponent<BottleAI>().TakeDamage(damage);
            print(other.name+"!!!");
        }
    }

    void Split()
    {
        GameObject.Instantiate(bullet, this.transform.position, Quaternion.Euler(0, 0, 0));
        GameObject.Instantiate(bullet, this.transform.position, Quaternion.Euler(0, 0, 45));
        GameObject.Instantiate(bullet, this.transform.position, Quaternion.Euler(0, 0, 90));
        GameObject.Instantiate(bullet, this.transform.position, Quaternion.Euler(0, 0, 135));
        GameObject.Instantiate(bullet, this.transform.position, Quaternion.Euler(0, 0, 180));
        GameObject.Instantiate(bullet, this.transform.position, Quaternion.Euler(0, 0, -135));
        GameObject.Instantiate(bullet, this.transform.position, Quaternion.Euler(0, 0, -90));
        GameObject.Instantiate(bullet, this.transform.position, Quaternion.Euler(0, 0, -45));
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
