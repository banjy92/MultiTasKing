using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleControl : MonoBehaviour {
    public float leftEnd;
    public float rightEnd;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (gameObject.transform.localPosition.x < leftEnd || gameObject.transform.localPosition.x > rightEnd)
        {
            GameManager.TriggerGameOver();
        }
	}
}
