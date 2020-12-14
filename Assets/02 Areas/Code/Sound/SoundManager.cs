using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ItLooksFamiliar.Sound
{
    public class SoundManager : MonoBehaviour
    {
        //##################
        //##    EDITOR    ##
        //##################
        public SoundDef[] Sounds;

        //###############
        //##  MEMBERS  ##
        //###############

        private static SoundManager sInstance;

        //################
        //##    MONO    ##
        //################

        private void Awake()
        {
            sInstance = this;
            foreach (SoundDef s in Sounds)
            {
                var source = gameObject.AddComponent<AudioSource>();
                source.clip = s.Clip;
                source.playOnAwake = false;
                source.loop = false;
                source.volume = s.Volume;
                s.Source = source;
            }
        }

        //#################
        //##  INTERFACE  ##
        //#################

        public void PlaySound(string name)
        {
            SoundDef sound = Array.Find(Sounds, s => s.Name.Equals(name));
            sound.Source.Play();
        }

        //#################
        //##  ACCESSORS  ##
        //#################
        public static SoundManager Instance => sInstance;
    }

}