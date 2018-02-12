using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C : MonoBehaviour {

    public int rings = 12;
    public float ringsSpacing = .5f;

	// Use this for initialization
	void Start () {
        float j = 0;
		for(var i = 1; i < rings; i++) {
            if (i > rings / 3) j += .015f;
            var inst = Instantiate(GameObject.Find("Circle"));
            inst.GetComponent<DrawCircle2D>().radius = 1.1f + i * ringsSpacing;
            inst.GetComponent<LerpToTargetPosition>().speed = .22f - i * .025f + j;
            inst.GetComponent<DrawCircle2D>().DoRenderer();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
