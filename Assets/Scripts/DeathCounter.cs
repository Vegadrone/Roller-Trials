using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCounter : MonoBehaviour
{
    private int deathCount;
    private const string deathCountKey = "DeathCount";

    private void Awake()
    {
        // Carica il contatore delle morti salvato
        deathCount = PlayerPrefs.GetInt(deathCountKey, 0);
    }
    public void IncrementDeathCount()
    {
        deathCount++;
    }
    public void ResetDeathCount()
    {
        deathCount = 0;
    }
    public int GetDeathCount()
    {
        return deathCount;
    }
}