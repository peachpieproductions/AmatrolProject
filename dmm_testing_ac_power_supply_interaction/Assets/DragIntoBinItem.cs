using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragIntoBinItem : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D collision) {
        if (Controller.stage == 0) {
            if (collision.CompareTag("Bin")) {
                if (!Controller.objectiveComplete) {
                    Controller.c.failedPanel.gameObject.SetActive(true);
                } 
                else {
                    if (collision.name == "GoodBin") {
                        Controller.c.successPanel.gameObject.SetActive(true);
                    } else {
                        Controller.c.failedPanel2.gameObject.SetActive(true);
                    }
                }
            }
        }
    }


}
