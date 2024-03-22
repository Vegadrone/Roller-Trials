using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCounter : MonoBehaviour
{
    public Text deathCounterText;
    private int deathCount = 0;

    private void Awake()
    {
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
            deathCounterText.text = "Death Counter: " + deathCount.ToString();
        }
    }
    public void ResetDeathCount()
    {
        deathCount = 0;
        UpdateDeathCountUI();
    }

}