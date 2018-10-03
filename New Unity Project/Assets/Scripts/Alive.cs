using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alive : MonoBehaviour {

    private  float  timer=0f;
    public string myName;
	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == "Blue") || (other.tag == "Red"))
        {
            Bottle bottle = other.GetComponent<Bottle>();
            bottle.KindOfBullet(myName);
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (timer > 9.9) Destroy(this.gameObject);
	}
}
