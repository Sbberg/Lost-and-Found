using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource BGM;

    public void ChangeBGM(AudioClip music) 
    {
        //checks to see if the trigger collider and the currently played music
        //is the exact same. if so, it returns and doesn't execute the rest of the code
        if (BGM.clip.name == music.name)
            return;
        
        
        //stops previous BGM and immediately starts a new one
        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
    }
}
