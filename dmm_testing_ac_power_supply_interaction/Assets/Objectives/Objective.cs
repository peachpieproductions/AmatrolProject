using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Objective")]
public class Objective : ScriptableObject {

    public float inputValue;
    public bool inputVDC;
    public float outputValue;
    public bool outputVDC;
    public Vector2 inputRangeToCheck;
    public Vector2 outputRangeToCheck;

    public bool partIsGood;
    public bool inputIsBad;

    public MultimeterSettingOverwrite[] inputSettingOverwrites;
    public MultimeterSettingOverwrite[] outputSettingOverwrites;

    private void OnEnable() {
        partIsGood = false;
        inputIsBad = false;
        //GeneratePart();
    }

    public void GeneratePart() {
        if (Random.value < .5f) { //50 % chance part will be good
            partIsGood = true;
        } else {
            if (Random.value < .5f) { //if part is bad, then 50% chance input will be bad, if not then output is bad.
                inputIsBad = true;
            }
        }
    }
    

}
