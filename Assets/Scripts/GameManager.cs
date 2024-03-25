using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [Header("Debugging")]
    [SerializeField] Debugger logger;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Debugger.DebuggerLoader(ref logger); 
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
        Application.Quit();
    }
}