using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipOnXMovement : MonoBehaviour {

    Vector3 posLastFrame;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (posLastFrame.x < transform.position.x) {
            transform.localEulerAngles = new Vector3(90, 0, 0);
        } else {
            transform.localEulerAngles = new Vector3(90, 180, 0);
        }

        posLastFrame = transform.position;
	}
}
