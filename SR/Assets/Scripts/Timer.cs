using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class Timer : MonoBehaviour
{
    float timer_f = 0f;
    int timer_i = 0;
    int minute = 0;
    int second = 0;
    
    // Update is called once per frame
    void Update()
    {
        timer_f += Time.deltaTime;
        timer_i = (int)timer_f;
        turn_time();
    }
    void turn_time()
    {
        minute = timer_i / 60;
        second = timer_i % 60;
    }
    public void timeRecord()
    {
        testResult.time.Add(string.Format("{0:00}:{1:00}", minute, second));
        
    }


}