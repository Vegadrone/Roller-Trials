using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathCounter : MonoBehaviour
{
    public static DeathCounter Instance;
    public TMP_Text deathCounterText;
    private int deathCount = 0;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        UpdateDeathCountUI();
    }

    public void IncreaseDeathCount()
    {
        deathCount++;
        UpdateDeathCountUI();
    }

    private void UpdateDeathCountUI()
    {
        if (deathCounterText != null)
        {
            deathCounterText.text = "Crash Counter: " + deathCount.ToString();
        }
    }
    public void ResetDeathCount()
    {
        deathCount = 0;
        UpdateDeathCountUI();
    }

}