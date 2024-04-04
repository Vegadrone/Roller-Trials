using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WinFlag : MonoBehaviour
{
    [Header("Game Values")]
    [SerializeField] float reloadTime = 0f;
    
    [Header("SFX")]
    [SerializeField]AudioClip winSoundClip;
    [SerializeField][Range(0f, 1f)]float winSoundClipVolume;
    [Header("Debugging")]
    [SerializeField] Debugger logger;

    CollisionDetection collisionDetection;

    void Awake()
    {
        collisionDetection = FindObjectOfType<CollisionDetection>(); 
        Debugger.DebuggerLoader(ref logger);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag =="Player" && !collisionDetection.hasCrashed)
        {
            SoundFXManager.instance.PlaySoundFXClip(winSoundClip, transform, winSoundClipVolume);
            Chronometer.instance.StopChronometer();
            GameManager.instance.Invoke("ReloadScene", reloadTime);
            logger.Log("HAI VVVINTO!!!", this);
        }
    }
}