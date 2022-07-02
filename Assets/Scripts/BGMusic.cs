using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour
{
    //Songs
    public AudioClip[] BgMusic; //Needs to be filled in in inspector

    //Other
    private int trackSelector { get; set; } 
    private int trackHistory { get; set; } 
    private bool playing { get; set; }

    //Drag
    private AudioSource audioS; 


    private void Awake()
    {
        audioS = GetComponent<AudioSource>(); //Audio Source
    }  
    void Update()
    {
        PlaySong();
    }
    void PlaySong()
    {
        //Check if song is playing
        playing = audioS.isPlaying; 
        if (!playing)
        {
            //Select song
            trackSelector = Random.Range(0, BgMusic.Length);
            //Check is song already played
            if (trackSelector != trackHistory)
            {
                //Play song
                audioS.PlayOneShot(BgMusic[trackSelector]);
                //Update track history
                trackHistory = trackSelector;
            }
        }
    }
}
