﻿using System.Collections;
using System.Collections.Generic;
using ItLooksFamiliar.Core;
using ItLooksFamiliar.Sound;
using Cinemachine;
using UnityEngine;
using ItLooksFamiliar.Effects;

namespace ItLooksFamiliar.Environment
{


    [RequireComponent(typeof(Animator))]
    public class ShipTransition : MonoBehaviour
    {
        [SerializeField]
        private GameObject Player;
        private Animator mAnim;
        private GameObject mCamera;
        private ScreenShake mShake;
        // Start is called before the first frame update
        void Start()
        {
            mAnim = GetComponent<Animator>();
            mCamera = GameObject.FindGameObjectWithTag("MainCamera").transform.GetChild(0).gameObject;
            mShake = GetComponent<ScreenShake>();
        }

        public void StartTransition()
        {
            SoundManager.Instance.PlaySound("PowerUp");
            UIManager.Instance.LockInventoryControls = true;
            UIManager.Instance.HideUI();
            mCamera.GetComponent<CinemachineVirtualCamera>().Follow = gameObject.transform;
            Player.SetActive(false);
            StartCoroutine(WaitForBoom(8.3f));
            mShake.ExecuteWithDelay(4f);
        }
        public void DisableShip()
        {
            gameObject.SetActive(false);
            Player.SetActive(false);
        }
        
        private IEnumerator WaitForBoom(float time)
        {
            yield return new WaitForSeconds(time);
            mAnim.Play("Ship_Jump");
            UIManager.Instance.InitateWorldTransitino();
            yield return null;
        }
    }

}