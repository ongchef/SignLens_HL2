using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Count_test1 : MonoBehaviour
{
    public TextMeshPro txt;
    public int total = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (txt == null)
        {
            txt = GetComponent<TextMeshPro>();
        }
    }

    // Update is called once per frame
    void Update() 
    {
       
    }

    public void changeText()
    {
        total = total + 1;
        txt.text = total.ToString();
        //Console.Write(total);
    }

}
