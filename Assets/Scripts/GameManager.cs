using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    DeathCounter deathCounter;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

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
