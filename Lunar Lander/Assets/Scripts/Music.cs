using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    //A reference to our audiosource & audioclip.
    AudioSource myAudioSource;

    public AudioClip myAudioClip;
    
    // Start is called before the first frame update
    void Start()
    {
        MusicMaker();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Handles our game music.
    void MusicMaker()
    {
        myAudioSource = GetComponent<AudioSource>();
        myAudioSource.clip = myAudioClip;
        myAudioSource.Play();
    }
}
