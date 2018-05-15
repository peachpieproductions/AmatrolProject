using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public struct MultimeterSettingOverwrite {
    public bool overwrite;
    public string[] numberText;
    public bool overwriteDecimal;
    public int decimalPlace;
    public bool minusSign;
}

[System.Serializable]
public struct MultimeterSetting {
    public string[] numberText;
    public int decimalPlace;
    public bool symbolDC;
    public bool symbolAC;
    public bool symbolMinusSign;
    public bool symbolTopRightArrow;
    public bool symbolMV;
    public bool symbolV;
    public bool symbolUA;
    public bool symbolA;
    public bool symbolMA;
    public bool symbolMO;
    public bool symbolO;
    public bool symbolKO;
}

public class Multimeter : MonoBehaviour {

    public string[] numberText;
    public int setting;
    [Range(0, 3)]
    public int decimalPlace;
    Transform decimalObject;
    Transform symbolsObject;
    Vector3 decStartPos;
    TextMeshPro[] numbersText = new TextMeshPro[4];
    public MultimeterSetting[] settings;

    //symbols
    bool symbolDC;
    bool symbolAC;
    bool symbolMinusSign;
    bool symbolTopRightArrow;
    bool symbolMV;
    bool symbolV;
    bool symbolUA;
    bool symbolA;
    bool symbolMA;
    bool symbolMO;
    bool symbolO;
    bool symbolKO;

    private void Start() {
        symbolsObject = transform.Find("Symbols");
        decimalObject = transform.Find("Decimal");
        foreach (TextMeshPro tmp in transform.Find("Numbers").GetComponentsInChildren<TextMeshPro>()) {
            numbersText[tmp.transform.GetSiblingIndex()] = tmp;
        }
        decStartPos = decimalObject.localPosition;
        UpdateMultimeter();
    }


    public void UpdateMultimeter() {

        var s = settings[setting];

        //Read Symbols Data
        symbolTopRightArrow = s.symbolTopRightArrow;
        symbolMV = s.symbolMV;
        symbolV = s.symbolV;
        symbolUA = s.symbolUA;
        symbolA = s.symbolA;
        symbolMA = s.symbolMA;
        symbolMO = s.symbolMO;
        symbolO = s.symbolO;
        symbolKO = s.symbolKO;
        symbolMinusSign = s.symbolMinusSign;
        symbolAC = s.symbolAC;
        symbolDC = s.symbolDC;

        //Update numbers texts
        for (var i = 0; i < numbersText.Length; i++) {
            numberText[i] = s.numberText[i];
            numbersText[i].text = numberText[i];
        }

        //Update decimal place
        decimalPlace = s.decimalPlace;
        if (decimalPlace == -1) decimalObject.gameObject.SetActive(false);
        else decimalObject.gameObject.SetActive(true);

        //Update Symbols
        foreach (Transform t in symbolsObject) {
            t.gameObject.SetActive(false);
        }
        if (symbolTopRightArrow) symbolsObject.GetChild(0).gameObject.SetActive(true);
        if (symbolMV) symbolsObject.GetChild(1).gameObject.SetActive(true);
        if (symbolV) symbolsObject.GetChild(2).gameObject.SetActive(true);
        if (symbolUA) symbolsObject.GetChild(3).gameObject.SetActive(true);
        if (symbolA) symbolsObject.GetChild(4).gameObject.SetActive(true);
        if (symbolMA) symbolsObject.GetChild(5).gameObject.SetActive(true);
        if (symbolMO) symbolsObject.GetChild(6).gameObject.SetActive(true);
        if (symbolO) symbolsObject.GetChild(7).gameObject.SetActive(true);
        if (symbolKO) symbolsObject.GetChild(8).gameObject.SetActive(true);
        if (symbolMinusSign) symbolsObject.GetChild(9).gameObject.SetActive(true);
        if (symbolAC) symbolsObject.GetChild(10).gameObject.SetActive(true);
        if (symbolDC) symbolsObject.GetChild(11).gameObject.SetActive(true);


        //Overwrite data for current connections/objective
        if (Controller.c.inputConnected) {
            if (Controller.c.currentObjective.inputSettingOverwrites[setting].minusSign) symbolsObject.GetChild(9).gameObject.SetActive(true);
            if (Controller.c.currentObjective.inputSettingOverwrites[setting].overwrite) {
                //overwrite input numbers
                for (var i = 0; i < numbersText.Length; i++) {
                    numbersText[i].text = Controller.c.currentObjective.inputSettingOverwrites[setting].numberText[i];
                }
            }
            if (Controller.c.currentObjective.inputSettingOverwrites[setting].overwriteDecimal) decimalPlace = Controller.c.currentObjective.inputSettingOverwrites[setting].decimalPlace;
        }
        if (Controller.c.outputConnected) {
            if (Controller.c.currentObjective.outputSettingOverwrites[setting].minusSign) symbolsObject.GetChild(9).gameObject.SetActive(true);
            if (Controller.c.currentObjective.outputSettingOverwrites[setting].overwrite) {
                //overwrite output numbers
                for (var i = 0; i < numbersText.Length; i++) {
                    numbersText[i].text = Controller.c.currentObjective.outputSettingOverwrites[setting].numberText[i];
                }
            }
            if (Controller.c.currentObjective.outputSettingOverwrites[setting].overwriteDecimal) decimalPlace = Controller.c.currentObjective.outputSettingOverwrites[setting].decimalPlace;
        }

        //Set decimal place
        if (decimalPlace != -1) decimalObject.localPosition = decStartPos + Vector3.right * decimalPlace * .51f;
        else decimalObject.gameObject.SetActive(false);
    }


}
