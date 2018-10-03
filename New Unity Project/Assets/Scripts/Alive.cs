using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alive : MonoBehaviour {

    private  float  timer=0f;
	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (timer > 9.9) Destroy(this.gameObject);
	}
}
