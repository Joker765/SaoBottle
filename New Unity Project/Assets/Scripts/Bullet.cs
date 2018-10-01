using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int damage = 30;
    private float speed = 8;

    private void Update()
    {
        transform.Translate(new Vector3(1,0) * speed * Time.deltaTime); //局部坐标系，直接前方
    }

    private void OnTriggerEnter(Collider other)
    {Die();
        if (other.tag == "Bottle")
        {
            other.GetComponent<Bottle>().TakeDamage(damage);
            
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
