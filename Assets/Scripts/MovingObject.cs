using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {
    public float speed;
    public Vector3 destructionPoint;

	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(speed,0,0);

        if (speed < 0 && transform.position.x <= destructionPoint.x)
        {
            Destroy(gameObject);
        } else if(speed > 0 && transform.position.x >= destructionPoint.x)
        {
            Destroy(gameObject);
        }
	}
}
