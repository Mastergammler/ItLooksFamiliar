using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItLooksFamiliar.Sound
{
    public class ShipSounds : MonoBehaviour, ISoundPlayback
    {
        public void Play(string soundName)
        {
            switch(soundName)
            {
                case "Add":
                    SoundManager.Instance.PlaySound("Install");
                    break;
            }
        }
    }
}