using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] sounds;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.Clip;
            s.Source.volume = s.Volume;
            s.Source.pitch = s.Pitch;
            s.Source.loop = s.Loop;
        }
        Play("BGMusic");
        DontDestroyOnLoad(gameObject);
    }



    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.SoundName == name);
        s.Source.Play();
    }

    public void ChangeVolume(string name, float amount)
    {
        Sound s = Array.Find(sounds, sound => sound.SoundName == name);
        s.Source.volume = amount;
    }
}
