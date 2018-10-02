using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string Enemy;
    private int damage = 40;
    private float speed = 8;

    private void Update()
    {
        transform.Translate(new Vector3(1,0) * speed * Time.deltaTime); //局部坐标系，直接前方
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall") Die();
        else if (other.tag==Enemy)
        {
            other.GetComponent<Bottle>().TakeDamage(damage);
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
