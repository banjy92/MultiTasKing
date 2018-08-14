using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareControl : MonoBehaviour {
    Rigidbody2D rb;
    public float jumpPower;
    private bool isJumping;
    private int jumpCount;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
        jumpCount = 2;
	}
	
	public void Jump()
    {
        if(!isJumping || jumpCount > 0)
        {
            isJumping = true;
            jumpCount--;
            rb.velocity = Vector2.zero;

            Vector2 jumpVel = new Vector2(0, jumpPower);
            rb.AddForce(jumpVel, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Platform")
        {
            isJumping = false;
            jumpCount = 2;
        }
    }
}
