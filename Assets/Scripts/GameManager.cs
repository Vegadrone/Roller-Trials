using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    DeathCounter deathCounter;
    [Header("Debugging")]
    [SerializeField] Debugger logger;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Debugger.DebuggerLoader(ref logger);

        deathCounter = FindObjectOfType<DeathCounter>(); 
    }
    private void Update() 
    {
      Chronometer.instance.UpdateChronometer();  
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
