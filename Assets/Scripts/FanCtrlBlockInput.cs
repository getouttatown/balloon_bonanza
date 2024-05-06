using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FanCtrlBlockInput : MonoBehaviour
{
    private float timerVal = 0.0f;
    void Start ()
    {
        var input = gameObject.GetComponent<TMP_InputField>();
        var se= new TMP_InputField.SubmitEvent();
        se.AddListener(SubmitVal);
        input.onEndEdit = se;

        //or simply use the line below, 
        //input.onEndEdit.AddListener(SubmitVal);  // This also works
    }

    private void SubmitVal(string arg0)
    {
        timerVal = float.Parse(arg0);
    }

    public float GetVal()
    {
        return timerVal;
    }
}
