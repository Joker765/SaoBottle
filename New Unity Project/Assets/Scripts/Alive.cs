using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alive : MonoBehaviour {

    private  float  timer=0f;
    public string myName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == "Blue") || (other.tag == "Red"))
        {
            if(other.GetComponent<Bottle>())
                other.GetComponent<Bottle>().KindOfBullet(myName);
            else other.GetComponent<BottleAI>().KindOfBullet(myName);
            Destroy(this.gameObject);
        }
    }

    void Update () {
        timer += Time.deltaTime;
        if (timer > 9.9) Destroy(this.gameObject);
	}
}
