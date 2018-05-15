using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandyScript : MonoBehaviour {

	
    public static Vector3 getMouseWorldPos() {
        return Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
    }

}
