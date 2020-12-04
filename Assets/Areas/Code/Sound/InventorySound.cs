using System.Collections;
using System.Collections.Generic;
using ItLooksFamiliar.Sound;
using UnityEngine;

namespace ItLooksFamiliar.Sound
{
    public class InventorySound : MonoBehaviour, ISoundPlayback
    {
        public void Play(string soundName)
        {
            switch (soundName)
            {
                case "Add":
                    //SoundManager.Instance.PlaySound("Collect");
                    break;
                case "Remove":
                    //SoundManager.Instance.PlaySound("ThrowAway");
                    break;
            }
        }
    }

}