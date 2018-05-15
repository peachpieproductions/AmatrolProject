using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour {

    public bool isPart;
    public bool isConnector;
    public bool isDragging;
    public bool forceUnsnap;
    public bool isSnapped;
    Vector3 startPos;
    Vector3 startGrabLocation;
    Vector3 mouseStartGrabLocation;

    private void Start() {
        startPos = transform.position;
    }

    public void ResetDraggable() {
        transform.position = startPos;
        isSnapped = false;
        if (isConnector) transform.GetChild(0).GetComponent<Snapper>().connection = 0;
    }

    private void OnMouseDown() {
        forceUnsnap = true;
        isDragging = true;
        if (isConnector) {
            Controller.c.isDraggingConnector = true;
            Controller.c.ToggleConnectorCircles(true);
            transform.GetChild(0).GetComponent<Snapper>().connection = 0;
        }
        if (isPart) {
            Controller.c.isDraggingPart = true;
            foreach (Draggable d in FindObjectsOfType<Draggable>()) {
                if (d.isConnector) d.ResetDraggable();
            }
        }
        startGrabLocation = transform.position;
        mouseStartGrabLocation = HandyScript.getMouseWorldPos();
    }

    private void OnMouseDrag() {
        isDragging = true;
        if (!isSnapped || forceUnsnap) {
            var diff = HandyScript.getMouseWorldPos() - mouseStartGrabLocation;
            transform.position = startGrabLocation + diff;
        }
    }

    private void OnMouseUp() {
        isDragging = false;
        if (isConnector) {
            Controller.c.isDraggingConnector = false;
            Controller.c.ToggleConnectorCircles(false);
        } 
        if (isPart) {
            Controller.c.isDraggingPart = false;
        }
    }


}
