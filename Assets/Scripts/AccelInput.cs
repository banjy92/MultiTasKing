using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelInput : MonoBehaviour {
    
    public float maxRot;
    public float minRot;
	
	// Update is called once per frame
	void Update () {
        float rotateVal = Input.acceleration.x;

        transform.Rotate(0, 0, -rotateVal);
        Vector3 currentRotation = transform.localRotation.eulerAngles;
        if(currentRotation.z < 180)
        {
            currentRotation.z = Mathf.Clamp(currentRotation.z, 0, maxRot);
        } else
        {
            currentRotation.z = Mathf.Clamp(currentRotation.z, minRot, 360);
        }
        
        
        transform.localRotation = Quaternion.Euler(currentRotation);

	}
}
