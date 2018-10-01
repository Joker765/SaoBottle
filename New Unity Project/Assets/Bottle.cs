using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour {

    public GameObject bullet;
    public Transform firePos;
    public bool isRed=true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isRed)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                GameObject go = GameObject.Instantiate(bullet, firePos.position, firePos.rotation) as GameObject;
            }
        } else
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                GameObject go = GameObject.Instantiate(bullet, firePos.position, firePos.rotation) as GameObject;
            }
        }
	}
}
