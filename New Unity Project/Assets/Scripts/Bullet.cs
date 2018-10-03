using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string Enemy;
    public string myName="bullet";
    public GameObject bullet;

    private Vector2 direction;
    private int damage = 40;
    private float speed = 8;

    private void Start()
    {
        direction= transform.right;// red axis in world space
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime,Space.World); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (myName == "bullet")
        {
            if (other.tag == "Wall") Die();
            else if (other.tag == Enemy)
            {
                other.GetComponent<Bottle>().TakeDamage(damage);
                Die();
            }
        }
        else if (myName == "Bounce")
        {
            if (other.tag == Enemy)
            {
                other.GetComponent<Bottle>().TakeDamage(damage);
                Die();
            }else if (other.tag == "Wall")
            {
                if (other.name == "HorizontalUp" || other.name == "HorizontalDown")
                    direction.y = -direction.y;
                else  direction.x = -direction.x;
            }
        }
        else if (myName=="Electric")
        {

        }
        else if (myName=="Split")
        {
            if (other.tag == "Wall") { Die(); Split(); }
            else if (other.tag == Enemy)
            {
                other.GetComponent<Bottle>().TakeDamage(damage);
                Die(); Split();
            }
        }
    }

    void Split()
    {
        GameObject.Instantiate(bullet);
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
