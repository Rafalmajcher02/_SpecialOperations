using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour
{
    public AudioClip[] BgMusic; // array of possible background songs
    public int trackSelector; //random number variable
    public int trackHistory; //saves the previous track number to not repeat it
    private AudioSource audioS; 
    bool playing; 
    void Start()
    {
        trackSelector = Random.Range(0, BgMusic.Length); //chooses an index, random song from array
        audioS = GetComponent<AudioSource>();
        audioS.PlayOneShot(BgMusic[trackSelector]); //plays random song
        trackHistory = trackSelector; //saves the history to avoid repeat
        playing = audioS.isPlaying; //checks is the song it playing
    }   
    void Update()
    {
        playing = audioS.isPlaying; //checks if song it playing
        if (!playing) //if not playing
        {
            trackSelector = Random.Range(0, BgMusic.Length); //gets random number
            if (trackSelector != trackHistory) //if random song is not the same as previous song play it, else random again
            {
                audioS.PlayOneShot(BgMusic[trackSelector]);
                trackHistory = trackSelector;
            }
        }
    }
}
