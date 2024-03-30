using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining;
    public TMP_Text timeText;
    public GameObject timerObject;
    private bool timerIsRunning = false;

    private void Start()
    {
        // Starts the timer automatically
        timerObject.SetActive(true);
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                timerObject.SetActive(false);
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:G}s", seconds);
        ///timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
}