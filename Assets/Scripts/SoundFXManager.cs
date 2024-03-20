using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    //Creiamo un singleton da poter richiamare in altre classi/oggetti
    //IMPORTANTE! I singleton devono essere solo UNO per SCENA
    //Possono essere richiamati in altre classi con NomeDelSingleton.instance.FunzioneCheMiServe
    //SoundFXManager.instance.PlaySoundFXCLip

    public static SoundFXManager instance;
    //Questa riga dichiara una variabile statica di tipo SoundFXManager 
    //chiamata instance. Una variabile statica è condivisa tra tutte le istanze 
    //di una classe e può essere accessibile senza dover istanziare la classe stessa.

    [SerializeField] private AudioSource soundFXobject;
    void Awake()
    {
       if (instance == null)
       {
         instance = this;
            if (instance == null) 
            
                instance = this; 
// Questa linea verifica se la variabile instance è nulla.Se è nulla, 
// significa che non esiste ancora un'istanza di SoundFXManager.
// Se instance è nulla, questa riga assegna l'istanza corrente di SoundFXManager 
// a instance. Questo fa sì che instance contenga sempre un riferimento 
// all'istanza corrente di SoundFXManager, garantendo 
// che ci sia solo un'istanza di questa classe durante l'esecuzione del gioco.
       } 
    }
    public void PlaySoundFXClip (AudioClip audioClip, Transform spawnTransform, float volume)
    {   
        //spawn del game object
        AudioSource audioSource = Instantiate (soundFXobject, spawnTransform.position, Quaternion.identity);
        //assegna una clip al game object
        audioSource.clip = audioClip;
        //assegna un volume
        audioSource.volume = volume;
        //suonalo
        audioSource.Play();
        //prendi la lunghezza dell' audio suonato...
        float clipLength = audioSource.clip.length;
        //...e usala per dire a Destroy quando distruggere il game object
        Destroy(audioSource.gameObject, clipLength);
    }
}
