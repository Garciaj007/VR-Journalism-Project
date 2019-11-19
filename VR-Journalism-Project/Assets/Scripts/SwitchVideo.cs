using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class SwitchVideo : MonoBehaviour{

    public VideoPlayer videoPlayer;
    public TextMeshPro title;
    public string[] sceneTitles;
    public List<VideoClip> videos;

    //-------------JUST FOR TESTING BUTTON AND CLICK EVENTS-------------//
    public GameObject obj;

    bool isPlaying;
    bool clicked = false;

    int videoPlayerIndex = 3;
    int sceneTitlesIndex = 0;



    // Start is called before the first frame update
    void Start(){
        //title = GetComponent<TextMeshPro> ();
        //obj = GetComponent<GameObject>();

        videoPlayer.clip = videos[videoPlayerIndex];
        videoPlayer.Play();
        isPlaying = false;
        Debug.Log(videoPlayerIndex);
    }

    // Update is called once per frame
    void Update(){
        SetSceneTitle();
        //title.SetText("0");
        Buttons();
    }

    


    public void PlayOrPause(){
        Debug.Log("CLICK");
        if (isPlaying)
            videoPlayer.Pause();
        else
            videoPlayer.Play();

    }

    void SetSceneTitle() {
        title.SetText(sceneTitles[sceneTitlesIndex]);
    }


    public void PlayNextClip() {       
        //videoPlayer.Stop();
        if (videoPlayerIndex == 4) {
            sceneTitlesIndex = 0;
            videoPlayerIndex = 0;
            videoPlayer.clip = videos[0];
            videoPlayer.Play();
        } else {
            sceneTitlesIndex++;
            videoPlayer.clip = videos[videoPlayerIndex++];
            videoPlayer.Play();
        }
        Debug.Log(videoPlayerIndex);

    }
    public void PlayPreviousClip(){
        //videoPlayer.Stop();
        if (videoPlayerIndex == 0) {
            sceneTitlesIndex = 4;
            videoPlayerIndex = 4;
            videoPlayer.clip = videos[4];
            videoPlayer.Play();
        } else {
            sceneTitlesIndex--;
            videoPlayer.clip = videos[videoPlayerIndex--];
            videoPlayer.Play();
        }
        Debug.Log(videoPlayerIndex);

    }


    //--------------------TESTING TO SEE IF SWITCHING VIDEOS WORKS WITH BUTTON PRESSES--------------------//
    void Buttons() {
        if (Input.GetKeyDown(KeyCode.V)) {
            PlayNextClip();
        }
        if (Input.GetKeyDown(KeyCode.C)) {
            PlayPreviousClip();
        }

        
    }
}
