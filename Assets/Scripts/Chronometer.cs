using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class Chronometer : MonoBehaviour
{   
    public static Chronometer instance;
    [SerializeField]TMP_Text chronometerText;
    private float startChronometer;
    private bool isChronometerRunning = true;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        startChronometer = Time.time;
    }

    public void UpdateChronometer()
    {
        if (isChronometerRunning)
        {
            float elapsedTime = Time.time - startChronometer;
            chronometerText.text = "Time:" + elapsedTime.ToString("F2");
        }
    }

    public void StopChronometer()
    {
        isChronometerRunning = false;
    }
}
