using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private bool isMusicEnabled = true;
    public void ToggleMusic()
    {
        isMusicEnabled = !isMusicEnabled;
        
        GetComponent<AudioSource>().enabled = isMusicEnabled;
    }
}
