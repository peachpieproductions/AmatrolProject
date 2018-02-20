using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C : MonoBehaviour {

    public int rings = 12;
    public float ringsSpacing = .5f;
    public float ringSpeed;
    public AnimationCurve curve;

	// Use this for initialization
	void Start () {
        float j = 0;
        var inst = GameObject.Find("Circle");
        inst.GetComponent<LerpToTargetPosition>().speed = curve.Evaluate(0f);
        for (var i = 1; i < rings; i++) {
            //Debug.Log();
            if (i > rings * .3f) j += .013f;
            inst = Instantiate(GameObject.Find("Circle"));
            inst.GetComponent<DrawCircle2D>().radius = 1.1f + i * ringsSpacing;
            inst.GetComponent<LerpToTargetPosition>().speed = curve.Evaluate(i * .083f);
            inst.GetComponent<DrawCircle2D>().DoRenderer();
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
