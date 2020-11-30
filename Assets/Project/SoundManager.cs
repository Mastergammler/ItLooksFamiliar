using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    private static SoundManager sInstance;
    public static SoundManager Instance => sInstance;
    public SoundDef[] Sounds;
    private void Awake() 
    {
        sInstance = this;
        foreach(SoundDef s in Sounds)
        {
            var source = gameObject.AddComponent<AudioSource>();
            source.clip = s.Clip;
            source.playOnAwake = false;
            source.loop = false;
            source.volume = s.Volume;
            s.Source = source;
        }
    }

    public void PlaySound(string name)
    {
        SoundDef sound = Array.Find(Sounds, s => s.Name.Equals(name));
        sound.Source.Play();
    }
}
