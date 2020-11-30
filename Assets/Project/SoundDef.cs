using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundDef 
{
    public string Name;
    public AudioClip Clip;
    [Range(0f,1f)]
    public float Volume;

    [HideInInspector]
    public AudioSource Source;
}
