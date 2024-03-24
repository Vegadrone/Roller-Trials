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
    

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        startChronometer = Time.time;
    }

    public void ChronometerStart()
    {
        chronometerText.text = "Time:" + startChronometer.ToString("F2");
    }
}
