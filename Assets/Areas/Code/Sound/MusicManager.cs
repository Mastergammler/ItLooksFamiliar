﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItLooksFamiliar.Sound
{

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
            //mAudioSource.Play();
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
            if(mAudioSource.isPlaying) return;
            mAudioSource.Play();
        }

    }

}