using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemsN : MonoBehaviour ,IFocusable,IInputClickHandler{

    public TextMesh testtext;

    public void OnFocusEnter()
    {
        testtext.text = "Enter" + gameObject.name;
    }

    public void OnFocusExit()
    {
        testtext.text = "Exit" + gameObject.name;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        testtext.text = "点击" + gameObject.name;
    }

    // Use this for initialization
    void Start ()
    {
        testtext = Camera.main.GetComponentInChildren<TextMesh>();
	}
	
	
}
