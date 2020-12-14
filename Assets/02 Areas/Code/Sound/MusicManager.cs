using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItLooksFamiliar.Sound
{

    public class MusicManager : MonoBehaviour
    {
        //##################
        //##    EDITOR    ##
        //##################

        [SerializeField]
        private AudioClip MainMusic;

        //###############
        //##  MEMBERS  ##
        //###############

        private AudioSource mAudioSource;
        private static MusicManager sInstance;

        //################
        //##    MONO    ##
        //################

        void Awake()
        {
            sInstance = this;
            DontDestroyOnLoad(this);
            mAudioSource = GetComponent<AudioSource>();
            mAudioSource.clip = MainMusic;
            mAudioSource.loop = true;
            //mAudioSource.Play();
        }

        //#################
        //##  INTERFACE  ##
        //#################

        public void PauseMusic()
        {
            mAudioSource.Pause();
        }

        public void ContinueMusic()
        {
            if(mAudioSource.isPlaying) return;
            mAudioSource.Play();
        }

        //#################
        //##  ACCESSORS  ##
        //#################

        public static MusicManager Instance => sInstance;

    }

}