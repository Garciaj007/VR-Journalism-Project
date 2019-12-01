using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;
using UnityEngine.Video;
using TMPro;
public class VideoManager : MonoBehaviour {

    [System.Serializable]
    public class VideoData
    {
        public string name;
        public VideoClip video;
    }

    public static VideoManager Instance { get; private set; }

    [SerializeField] private PinchSlider slider = null;
    [SerializeField] private TextMeshPro sliderTitle = null;
    [SerializeField] private VideoPlayer videoPlayer = null;
    [SerializeField] private TextMeshPro title = null;
    [SerializeField] private List<VideoData> videos = new List<VideoData>();
    [Space]
    [SerializeField] private int currentVideoIndex = 0;

   public bool IsSliderActive { get; set; }

   void Awake()
    {
        if(Instance != null && Instance != this)
            Destroy(gameObject);

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetCurrentVideo();
    }

    // Update is called once per frame
    void Update()
    {
        if (!videoPlayer.isPlaying) return;
        
        if(!IsSliderActive)
            UpdateSlider();
    }

    private void UpdateSlider()
    {
        sliderTitle.text = Utils.TimeFormat.FormatTime(videoPlayer.time);
        slider.SliderValue = GetVideoPos(videoPlayer.time);
    }

    private void SetCurrentVideo()
    {
        if(videoPlayer.isPlaying) videoPlayer.Stop();

        slider.SliderValue = 0.0f;
        sliderTitle.text = "00:00";
        title.text = videos[currentVideoIndex].name;
        videoPlayer.clip = videos[currentVideoIndex].video;

        videoPlayer.Play();
    }

    private double GetSliderPos(double value) => 
        Utils.Mathf.Map(value, 0.0, 1.0, 0.0, videoPlayer.clip.length);

    private float GetVideoPos(double value) =>
        (float) Utils.Mathf.Map(value, 0.0, videoPlayer.clip.length, 0.0, 1.0);

    public void SetPlayerTime(SliderEventData e)
    {
        videoPlayer.time = GetSliderPos(e.NewValue);
        sliderTitle.text = Utils.TimeFormat.FormatTime(videoPlayer.time);
    }

    public void PlayOrPause()
    {
        if (videoPlayer.isPlaying)
            videoPlayer.Pause();
        else
            videoPlayer.Play();
    }

    public void PlayNextClip()
    {
        ++currentVideoIndex;
        currentVideoIndex = LimitVideoIndex();
        SetCurrentVideo();
    }

    public void PlayPreviousClip()
    {
        --currentVideoIndex;
        currentVideoIndex = LimitVideoIndex();
        SetCurrentVideo();
    }

    private int LimitVideoIndex() => currentVideoIndex > videos.Count - 1 ? 0 :
        currentVideoIndex < 0 ? videos.Count - 1 : currentVideoIndex;
}
