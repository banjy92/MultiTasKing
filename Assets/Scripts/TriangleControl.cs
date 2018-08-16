using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleControl : MonoBehaviour {
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    public void ReverseGrav()
    {
        rb.gravityScale *= -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Obstacle")
        {
            GameManager.TriggerGameOver();
        }
    }
}
