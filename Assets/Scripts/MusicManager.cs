using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public bool MusicEnabled = true;
    public Toggle toggle;
    public AudioSource MusicSource;
    public AudioClip[] MusicClips;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("musicenabled") == 1) {
            MusicEnabled = true;
            toggle.isOn = false;
        } else {
            MusicEnabled = false;
            toggle.isOn = true;
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (!MusicSource.isPlaying && MusicEnabled) {
            PlayMusic();
        }
    }

    public void PlayMusic() {
        MusicSource.clip = MusicClips[Random.Range(0,MusicClips.Length)];
        MusicSource.Play();
    }

    [ContextMenu("StopMusic")]
    public void StopMusic() {
        MusicEnabled = false;
        PlayerPrefs.SetInt("musicenabled",0);
        MusicSource.Stop();
    }
    [ContextMenu("StartMusic")]
    public void StartMusic() {
        MusicEnabled = true;
        PlayerPrefs.SetInt("musicenabled",1);
        MusicSource.clip = MusicClips[Random.Range(0,MusicClips.Length)];
        MusicSource.Play();
    }
    [ContextMenu("SetEnabled")]
    public void SetEnabled(bool disabled) {
        if (disabled) {
            StopMusic();
        } else {
            StartMusic();
        }
    }
    
}
