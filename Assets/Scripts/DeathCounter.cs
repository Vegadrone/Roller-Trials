using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathCounter : MonoBehaviour
{
    [Header("Debugging")]
    [SerializeField] Debugger logger;
    [SerializeField] TMP_Text deathCounterText;
    private int deathCounter;
    private int currentDeathCount;

    private void Awake() 
    {
        Debugger.DebuggerLoader(ref logger);
        PlayerPrefs.SetInt("DeathCount", deathCounter);
        deathCounterText.text = "Crash Count: " + deathCounter.ToString();
    }

    public void UpdateDeathCounter()
    {
        deathCounter++;
        logger.Log(deathCounter, this);
    }
}