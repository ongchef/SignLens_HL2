using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class showResult : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshPro t;
    void Start()
    {
        //t.text = string.Join(", ", testResult.result) + "\n" + string.Join(", ", testResult.time);
        int totalScore = 0;
        foreach (int s in testResult.scores) 
        {
            totalScore += s;
        }

        t.text= totalScore+"";
    }
}
