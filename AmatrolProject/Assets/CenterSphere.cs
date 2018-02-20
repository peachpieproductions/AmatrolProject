using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CenterSphere : MonoBehaviour {

    Slider slider;
    float xSpeed;


	// Use this for initialization
	void Start () {
        slider = GameObject.Find("Slider").GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        xSpeed = (slider.value * .6f) - .3f;
        transform.position += new Vector3(xSpeed, 0);
        if (transform.position.x < -8.8f) transform.position += new Vector3(8.8f * 2, 0);
        if (transform.position.x > 8.8f) transform.position += new Vector3(-8.8f * 2, 0);
    }
}
