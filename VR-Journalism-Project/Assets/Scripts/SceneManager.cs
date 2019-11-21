using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance { get; private set; }

    private readonly float[] volumesArray = {-80.0f, -20.0f, -2.0f, 4.0f};
    private int volumeIndex = 3;

    [SerializeField] private AudioMixer mainAudioMixer;

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);

        Instance = this;
    }

    private int FindVolumeIndex()
    {
        volumeIndex++;
        volumeIndex = volumeIndex > volumesArray.Length - 1 ? 0 :
            volumeIndex < 0 ? volumesArray.Length - 1 : volumeIndex;
        return volumeIndex;
    }

    public void SetAudioLevel() =>
        mainAudioMixer.SetFloat("MasterVolume", volumesArray[FindVolumeIndex()]);
}
