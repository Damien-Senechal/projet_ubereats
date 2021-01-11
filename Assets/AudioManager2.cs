using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager2 : MonoBehaviour
{
    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = 1;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Pause();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    public void setVolumeMusic(float volumeMusic)
    {
        Sound s = Array.Find(sounds, sound => sound.name.Equals("Theme"));
        s.source.volume = volumeMusic;
    }

    public void setMainVolume(float volumeMain)
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = volumeMain;
        }
    }
}
