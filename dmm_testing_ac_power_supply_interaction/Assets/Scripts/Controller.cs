using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour {

    public Transform meter;
    public Transform meterDial;
    public Transform introPanel;
    public Transform failedPanel;
    public Transform failedPanel2;
    public Transform successPanel;
    public float inVoltage;
    public float outVoltage;
    public static Controller c;
    public static int stage;
    public static bool objectiveComplete;
    public Objective currentObjective;
    public Objective[] objectives;
    public int meterSetting;
    public bool inputConnected;
    public bool outputConnected;
    public bool leftTested;
    public bool rightTested;
    public bool isDraggingConnector;
    public bool isDraggingPart;
    public Multimeter multimeter;

    private void Awake() {
        c = this;
    } 

    private void Start() {
        currentObjective = objectives[Random.Range(0, objectives.Length)];
        inVoltage = currentObjective.inputValue;
        outVoltage = currentObjective.outputValue;
    }

    private void Update() {

        int inputs = 0;
        int outputs = 0;
        //Input Output detection
        foreach (Snapper s in FindObjectsOfType<Snapper>()) {
            if (s.connection == 1) {
                inputs++;
            }
            if (s.connection == 2) {
                outputs++;
            }
        }

        if (inputs == 2) {
            if (!inputConnected) { inputConnected = true; multimeter.UpdateMultimeter(); }
        } 
        else inputConnected = false;

        if (outputs == 2) {
            if (!outputConnected) { outputConnected = true; multimeter.UpdateMultimeter(); }
        } 
        else outputConnected = false;

        //Objective Complete detection
        if (!objectiveComplete) {
            //check for input test
            if (!leftTested) {
                if (inputConnected) {
                    if (multimeter.setting > currentObjective.inputRangeToCheck.x && multimeter.setting < currentObjective.inputRangeToCheck.y) {
                        leftTested = true;
                    }
                }
            }
            //check for output test
            if (!rightTested) {
                if (outputConnected) {
                    if (multimeter.setting > currentObjective.outputRangeToCheck.x && multimeter.setting < currentObjective.outputRangeToCheck.y) {
                        rightTested = true;
                    }
                }
            }
            //check for objective completed
            if (leftTested && rightTested) {
                objectiveComplete = true;
            }
        }

        //Intro Panel, gives you initial instruction, once its 100% faded in, you can click it away.
        if (introPanel.gameObject.activeSelf) {
            if (introPanel.GetComponent<CanvasGroup>().alpha < 1) {
                introPanel.GetComponent<CanvasGroup>().alpha += .005f;
            } else {
                if (Input.GetMouseButtonDown(0)) {
                    introPanel.gameObject.SetActive(false);
                }
            }
        }

        //If the failed panel is active, close is with click or space
        if (failedPanel.gameObject.activeSelf) {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter)) {
                failedPanel.gameObject.SetActive(false);
            }
        }
        if (failedPanel2.gameObject.activeSelf) {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter)) {
                failedPanel2.gameObject.SetActive(false);
            }
        }
        if (successPanel.gameObject.activeSelf) {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter)) {
                successPanel.gameObject.SetActive(false);
            }
        }
    }

    public void ToggleConnectorCircles(bool toggle) {
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("SnapZone")) {
            go.GetComponent<SpriteRenderer>().enabled = toggle;
        }
    }


}
