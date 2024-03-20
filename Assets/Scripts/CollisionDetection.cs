using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetection : MonoBehaviour
{
   [SerializeField] float reloadTime = 0f;
   [Header("SFX")]
   [SerializeField] AudioClip crashSoundClip;
   [SerializeField][Range(0f, 1f)] float crashSoundClipVolume;
   [Header("Debugging")]
   [SerializeField]Debugger logger;
   public float deathCounter;
   bool hasCrashed;
   void Awake()
   {
      Debugger.DebuggerLoader(ref logger);
   }

   private void OnCollisionEnter2D(Collision2D other) 
   {
      if (!hasCrashed)
      {
         hasCrashed = true;
         FindAnyObjectByType<PlayerController>().DisableControls();
         SoundFXManager.instance.PlaySoundFXClip(crashSoundClip, transform, crashSoundClipVolume);
         deathCounter++;
         Invoke("ReloadScene", reloadTime);
         logger.Log("OUCH!" + " | " + "Il numero delle tue morti è:" + " " + deathCounter, this);  
      }
      DontDestroyOnLoad(this);
   }

   private void ReloadScene()
   {
    SceneManager.LoadScene(0);
   }
}
