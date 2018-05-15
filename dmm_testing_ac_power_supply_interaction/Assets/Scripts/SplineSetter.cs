using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineSetter : MonoBehaviour {

    private void Update() {
        GetComponent<Spline>().nodes[0].SetDirection(Vector3.down);
        //GetComponent<Spline>().nodes[0].SetPosition();
        GetComponent<Spline>().nodes[1].SetDirection(Vector3.up);
    }


}
