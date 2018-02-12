using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpToTargetPosition : MonoBehaviour {

    public Transform target;
    public float speed = .1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, target.position, speed);
	}
}
