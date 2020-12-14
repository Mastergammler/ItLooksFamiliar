using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItLooksFamiliar.Sound
{

    [RequireComponent(typeof(AudioSource))]
    public class AnimationSounds : MonoBehaviour
    {
        //##################
        //##    EDITOR    ##
        //##################

        [SerializeField]
        private AudioClip[] clips;


        //###############
        //##  MEMBERS  ##
        //###############

        private AudioSource mAudio;

        //################
        //##    MONO    ##
        //################

        private void Awake()
        {
            mAudio = GetComponent<AudioSource>();
            mAudio.playOnAwake = false;
            mAudio.loop = false;
        }

        //#################
        //##  INTERFACE  ##
        //#################

        public void PlayRandomSound()
        {
            int index = Random.Range(0, clips.Length - 1);
            mAudio.clip = clips[index];
            mAudio.Play();
        }
    }

}