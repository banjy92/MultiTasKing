using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelInput : MonoBehaviour {

    public float speed = 1f;
    
	
	// Update is called once per frame
	void Update () {
        float rotateVal = Input.acceleration.x;

        transform.Rotate(0, 0, -rotateVal);
	}
}
