using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]bool showLogs;
    [SerializeField]string prefix;
    [SerializeField]Color prefixColor;
    string hexColor;
  
    void OnValidate()
    {
        hexColor = "#" + ColorUtility.ToHtmlStringRGB(prefixColor);
    }

    public void Log(object message, Object sender)
    {   
        if (this != null)
        {
            if(!showLogs) return;
            Debug.Log($"<color={hexColor}>{prefix}</color>: {message}");
        }
        else
        {
            Debug.LogError("DEBUGGER MANCANTE");
        }
    }

    public static void DebuggerLoader(ref Debugger logger)
    {
        if (logger == null)
        {
            logger = FindObjectOfType<Debugger>();
            if (logger == null)
            {
                Debug.LogError("Debugger non trovato!");
            }
        }
    }
}
