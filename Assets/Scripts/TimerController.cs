using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;

    public Text instructions;
    public Text timeCounter;
    public Text finalTime;

    

    private TimeSpan timePlaying;
    private bool timerGoing;
    private bool timerNotFinished;

    private float elapsedTime;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        timeCounter.text = "Time: 00:00.00";
        timerGoing = false;

        instructions.enabled = true;
        timeCounter.enabled = false;
        finalTime.enabled = false;
        
        timerNotFinished = true;
    }

    public void BeginTimer()
    {
        instructions.enabled = false;
        timeCounter.enabled = true;
        timerGoing = true; 
        elapsedTime = 0f;
        
        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
        
        
        finalTime.enabled = true;
        timeCounter.enabled = false;

        timerNotFinished = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing && timerNotFinished)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;
            finalTime.text = "Final " + timePlayingStr;

            yield return null;
        }
    }
}
