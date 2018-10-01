using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public GameObject[] randomItem;
    public Transform Pos;

    private float timer = 0f;
    private int time = 0;

	// Use this for initialization
	void Start () {
        int i = Random.Range(0, 4);
        GameObject.Instantiate(randomItem[i], Pos.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 12)
        {
            int i = Random.Range(0, 4);
            GameObject.Instantiate(randomItem[i], Pos.position, Quaternion.identity);
            time++; timer = 0;
            if (time >= 4)
            {
                time = 0; 
                //TODO
            }
        }
	}
}
