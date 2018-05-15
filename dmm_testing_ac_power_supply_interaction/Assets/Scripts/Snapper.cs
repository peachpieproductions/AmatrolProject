using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapper : MonoBehaviour {

    Transform snapTarget;
    public int connection; // 0 - no connection, 1 - input connection, 2 - output connection

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.transform.CompareTag("SnapZone") && !Controller.c.isDraggingPart) {
            snapTarget = collision.transform;
            transform.parent.GetComponent<Draggable>().isSnapped = true;
            transform.parent.GetComponent<Draggable>().forceUnsnap = false;
            transform.parent.position = collision.transform.position - transform.localPosition;
            if (collision.GetComponent<SnapZone>().input) connection = 1;
            else connection = 2;
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.transform.CompareTag("SnapZone") && !Controller.c.isDraggingPart) {
            transform.parent.GetComponent<Draggable>().isSnapped = true;
            transform.parent.position = collision.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.transform.CompareTag("SnapZone") && !Controller.c.isDraggingPart) {
            snapTarget = null;
            transform.parent.GetComponent<Draggable>().isSnapped = false;
            
        }
    }

}
