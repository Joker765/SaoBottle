using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Web : MonoBehaviour {

    private Rigidbody2D grab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rigidbody2D>())
            grab = collision.GetComponent<Rigidbody2D>();
        else grab = collision.GetComponentInParent<Rigidbody2D>();

        grab.drag = 1f;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Rigidbody2D>())
            grab = collision.GetComponent<Rigidbody2D>();
        else grab = collision.GetComponentInParent<Rigidbody2D>();

        grab.drag = 0.1f;
    }
}
