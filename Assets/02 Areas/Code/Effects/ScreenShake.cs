using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace ItLooksFamiliar.Effects
{
    public class ScreenShake : MonoBehaviour
    {
        //##################
        //##    EDITOR    ##
        //##################

        public float ScreenShakeAmplitude = 1.5f;
        public float FrequencyRamp = 10f;
        public float ShakeTime = 1f;

        //###############
        //##  MEMBERS  ##
        //###############

        private CinemachineVirtualCamera mCamera;
        private CinemachineBasicMultiChannelPerlin mShakeParams;
        private Coroutine mCurrentRoutine;
        private delegate Coroutine ExecuteShake();

        //################
        //##    MONO    ##
        //################
            
        void Awake()
        {
            mCamera = GameObject.FindWithTag("MainCamera").GetComponentInChildren<CinemachineVirtualCamera>();
            if(mCamera == null) Debug.LogError("Cinemachine virtual camera not found, but is required!");

            mShakeParams = mCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            if(mShakeParams == null) Debug.LogError("Virtual camera is missing the noise component");
        }

        //#################
        //##  INTERFACE  ##
        //#################

        public void TimedExecution(float shakeTime)
        {
            executeShake(() => StartCoroutine(shakeCustomTime(shakeTime)));
        }

        public void ExecuteDefault()
        {
            executeShake(() => StartCoroutine(shakeAutoDisable()));
        }

        public void ExecuteWithDelay(float delay)
        {
            executeShake(() => StartCoroutine(shakeAutoDisable(delay)));
        }

        //###############
        //##  METHODS  ##
        //###############

        private void executeShake(ExecuteShake shake)
        {
            if(mCurrentRoutine != null) StopCoroutine(mCurrentRoutine);
            mCurrentRoutine = shake.Invoke();
        }

        // Noise params have to be reset, else camera will shake all the time
        private IEnumerator shakeAutoDisable(float delay = 0f)
        {
            yield return new WaitForSeconds(delay);

            setShakeParams();
            yield return new WaitForSeconds(ShakeTime);

            resetShakeParams(); 
            yield return null;
        }

        private IEnumerator shakeCustomTime(float shakeTime)
        {       
            setShakeParams();
            yield return new WaitForSeconds(shakeTime);

            resetShakeParams();
            yield return null;
        }

        private void setShakeParams()
        {
            mShakeParams.m_AmplitudeGain = ScreenShakeAmplitude;
            mShakeParams.m_FrequencyGain = FrequencyRamp;
        }
        private void resetShakeParams()
        {
            mShakeParams.m_AmplitudeGain = 0f;
            mShakeParams.m_FrequencyGain = 0f;
        }
    }
}