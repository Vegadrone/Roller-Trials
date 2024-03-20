using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerBladesSFX : MonoBehaviour
{
    AudioSource audioSource;
    void Start()
    {
       audioSource = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.Play();
    }
}
