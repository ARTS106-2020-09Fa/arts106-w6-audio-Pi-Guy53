using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAudio : MonoBehaviour
{
    public AudioSource audios; 
    public void PlayClip(AudioClip clip)
    {
        audios.PlayOneShot(clip);
    }
}
