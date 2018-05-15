using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterDial : MonoBehaviour {

    Multimeter multimeter;
    Quaternion originalRotation;
    float startAngle = 0;
    Quaternion finalRotation;

    private void Start() {
        multimeter = transform.parent.GetComponent<Multimeter>();
    }

    private void OnMouseDown() {
        originalRotation = transform.rotation;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 vector = Input.mousePosition - screenPos;
        startAngle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
    }

    private void OnMouseDrag() {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 vector = Input.mousePosition - screenPos;
        float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        Quaternion newRotation = Quaternion.AngleAxis(angle - startAngle, transform.forward);
        newRotation.y = 0; 
        newRotation.eulerAngles = new Vector3(0, 0, newRotation.eulerAngles.z);
        finalRotation = originalRotation * newRotation;

        transform.eulerAngles = new Vector3(0, 0, (int)(finalRotation.eulerAngles.z / 12) * 12); //apply final rotation, lock to 12 degree increments
        var setting = Mathf.RoundToInt(transform.eulerAngles.z / 12);
        if (multimeter.setting != setting) {
            multimeter.setting = setting;
            multimeter.UpdateMultimeter();
        }
    }

}
