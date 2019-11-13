using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance { get; private set; }

    private float[] volumesArray = {-80.0f, -30.0f, -10.0f, 0.0f};
    private float volumeIndex = 0;

    [SerializeField] private AudioMixer mainAudioMixer;

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);

        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAudioLevel(float volumeLevel) =>
        mainAudioMixer.SetFloat("MasterVolume", volumeLevel);
}
