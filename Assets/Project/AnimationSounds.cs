using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AnimationSounds : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] clips;

    private AudioSource mAudio;

    private void Awake() 
    {
        mAudio = GetComponent<AudioSource>();
        mAudio.playOnAwake = false;
        mAudio.loop = false;
    }

    public void PlayRandomSound()
    {
        int index = Random.Range(0,clips.Length-1);
        mAudio.clip = clips[index];
        mAudio.Play();
    }
}
