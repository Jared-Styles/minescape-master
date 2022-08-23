using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;

   // public Text instructions;
   // public Text timeCounter;
   // public Text finalTime;

    public TextMeshProUGUI timeCounterPro;
    public TextMeshProUGUI finalTimePro;

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
        //timeCounter.text = "Time: 00:00.00";
        timeCounterPro.text = "";

        timerGoing = false;

       // instructions.enabled = true;

        //timeCounter.enabled = false;
        timeCounterPro.enabled = true;

        //finalTime.enabled = false;
        finalTimePro.enabled = false;


        timerNotFinished = true;
    }

    public void BeginTimer()
    {
        //instructions.enabled = false;

        //timeCounter.enabled = true;
        //timeCounterPro.enabled = true;


        timerGoing = true; 
        elapsedTime = 0f;
        
        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
        
        
        //finalTime.enabled = true;
        finalTimePro.enabled = true;

       // timeCounter.enabled = false;
        timeCounterPro.enabled = false;

        timerNotFinished = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing && timerNotFinished)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");

            //timeCounter.text = timePlayingStr;
            timeCounterPro.text = timePlayingStr;

            //finalTime.text = "Final " + timePlayingStr;
            finalTimePro.text = "Final " + timePlayingStr;

            yield return null;
        }
    }
}
