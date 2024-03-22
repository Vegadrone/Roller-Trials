using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    DeathCounter deathCounter;

    void Awake()
    {
       deathCounter = FindObjectOfType<DeathCounter>(); 
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        deathCounter.ResetDeathCount();
        Application.Quit();
    }
}
