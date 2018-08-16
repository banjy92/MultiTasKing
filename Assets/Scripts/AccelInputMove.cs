using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelInputMove : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb;
    Matrix4x4 baseMatrix = Matrix4x4.identity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Calibrate();
    }

    // Update is called once per frame
    void Update()
    {
        //float moveVal = Input.acceleration.y
        float moveVal = baseMatrix.MultiplyVector(Input.acceleration).y;
        Vector3 direction = new Vector3(0, moveVal*speed, 0);
        if( !rb.isKinematic)
        {
            rb.velocity = direction;
        }
        
    }
    
    public void Calibrate()
    {
        Quaternion rotate = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, -1.0f), Input.acceleration);

        Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, rotate, new Vector3(1.0f, 1.0f, 1.0f));

        baseMatrix = matrix.inverse;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            GameManager.TriggerGameOver();
        }
    }
}
