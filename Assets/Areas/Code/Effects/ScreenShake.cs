using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace ItLooksFamiliar.Effects
{
    public class ScreenShake : MonoBehaviour
    {
        public float ScreenShakeAmplitude = 1.5f;
        public float FrequencyRamp = 10f;
        public float ShakeTime = 1f;
        //###############
        //##  MEMBERS  ##
        //###############
        private CinemachineVirtualCamera mCamera;
        private Coroutine mCurrentRoutine;

        //################
        //##    MONO    ##
        //################
        void Start()
        {
            mCamera = GameObject.FindWithTag("MainCamera").GetComponentInChildren<CinemachineVirtualCamera>();
        }

        private IEnumerator screenShakeWithAutoDisable(float delay = 0f)
        {
            yield return new WaitForSeconds(delay);
            if(mCamera != null)
            {
                var noise = mCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                noise.m_AmplitudeGain = ScreenShakeAmplitude;
                noise.m_FrequencyGain = FrequencyRamp;
                yield return new WaitForSeconds(ShakeTime);
                noise.m_AmplitudeGain = 0f;
                noise.m_FrequencyGain = 0f;
            }
            yield return null;
        }

        public void Execute()
        {
            if(mCurrentRoutine != null)
            {
                StopCoroutine(mCurrentRoutine);
            }
            mCurrentRoutine = StartCoroutine(screenShakeWithAutoDisable());
        }

        public void ExecuteWithDelay(float delay)
        {
            if(mCurrentRoutine != null)
            {
                StopCoroutine(mCurrentRoutine);
            }
            mCurrentRoutine = StartCoroutine(screenShakeWithAutoDisable(delay));
        }

    }
}