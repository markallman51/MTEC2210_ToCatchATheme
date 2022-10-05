using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 Goal: Have the music player play the entire track from the beginning first.
When it finished, play the looped version, which starts from the middle of the track
 */
public class MusicPlayer : MonoBehaviour
{

    public AudioSource main;
    public AudioSource loop;

    private bool mainFinished = false;
    private bool loopPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        //play the main track once the game starts
        main.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //when the main track finished, set mainFin to true
        if(!main.isPlaying)
        {
            mainFinished = true;
        }

        //when the main track is finished, play the loop track and set loopPlying to true
        if(mainFinished && !loopPlaying)
        {
            //play the loop track
            loop.Play();
            loopPlaying = true;
        }

        //if the loop track stops after it was already playing, play it again
        if(loopPlaying && !loop.isPlaying)
            loop.Play();
    }
}
