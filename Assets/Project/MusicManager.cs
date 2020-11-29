using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource mAudioSource;
    [SerializeField]
    private AudioClip MainMusic;
    private static MusicManager mInstance;
    public static MusicManager Instance => mInstance;
    
    //################
    //##    MONO    ##
    //################

    void Awake()
    {
        mInstance = this;
        DontDestroyOnLoad(this);
        mAudioSource = GetComponent<AudioSource>();
        mAudioSource.clip = MainMusic;
        mAudioSource.loop = true;
        mAudioSource.Play();
    }

    //###############
    //##  METHODS  ##
    //###############

    public void PauseMusic()
    {
        mAudioSource.Pause();
    }
    
    public void ContinueMusic()
    {
        mAudioSource.Play();
    }

}
