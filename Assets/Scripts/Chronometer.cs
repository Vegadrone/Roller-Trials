using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class Chronometer : MonoBehaviour
{   
    public static Chronometer instance;
    [Header("Text")]
    [SerializeField]TMP_Text chronometerText;
    [Header("Debugging")]
    [SerializeField] Debugger logger;
    private float startChronometer;
    private bool isChronometerRunning = true;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Debugger.DebuggerLoader(ref logger);
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
