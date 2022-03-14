using UnityEngine.Audio;
using UnityEngine;
using System;

[System.Serializable]
public class soundData
{
    public string name;

    public AudioClip clip;
    [Range(0f, 1f)]
    public float volumn;

    public bool isLoop = false;

    [HideInInspector]
    public AudioSource source;
}

public class sound : MonoBehaviour
{
    public static sound Instance;
    public bool isMute; 
    public soundData[] soundsData;

    soundData currentSong;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        foreach (soundData item in soundsData)
        {
            item.source = gameObject.AddComponent<AudioSource>();
            item.source.clip = item.clip;
            item.source.volume = item.volumn;
            item.source.loop = item.isLoop;
        }

        mute(isMute);
    }

    public void mute(bool muted)
    {
        foreach (soundData item in soundsData)
        {
            item.source.mute = muted;
        }
    }

    public void playSound(string name)
    {
        soundData s = Array.Find(soundsData, temp => temp.name == name);
        if (s == null)
            return;

        s.source.Play();
    }

    public void playSong(string name)
    {
        soundData s = Array.Find(soundsData, temp => temp.name == name);
        if (s == null)
            return;

        s.source.Play();
        currentSong = s;
    }

    public void stopSong()
    {
        if(currentSong != null)
            currentSong.source.Stop();
    }
}
