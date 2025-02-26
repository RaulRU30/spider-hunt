using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float timeRemaining = 60;
    public bool timerIsRunning = false;
    
    public TMP_Text timeText;
    private bool _istimeTextNotNull;

    void Start()
    {
        _istimeTextNotNull = timeText != null;
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
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
    
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        
        if(_istimeTextNotNull ) timeText.text = $":{seconds:00}";
    }
    
    public void RestartTimer()
    {
        timeRemaining = 60;
        timerIsRunning = true;
    }
    
    public void ToggleTimer()
    {
        timerIsRunning = !timerIsRunning;
    }
}
