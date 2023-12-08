using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayBack : MonoBehaviour
{
    public VideoClip[] videoclips;
    private VideoPlayer videoplayer;
    private int videoClipIndex;

    private void Awake(){
        videoplayer = GetComponent<VideoPlayer>();
    }

    void Start()
    {
        videoplayer.clip = videoclips[0];
    }

    public void PlayPause(){

    if(videoplayer.isPlaying){
        videoplayer.Pause();
        
    }
    else{
        videoplayer.Play();
    }

    }


    public void playNext(){
        videoClipIndex++;
        if(videoClipIndex >= videoclips.Length){
            videoClipIndex= videoClipIndex % videoclips.Length;
        }
        videoplayer.clip = videoclips[videoClipIndex];
    }

}
