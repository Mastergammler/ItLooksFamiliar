using System.Collections;
using System.Collections.Generic;
using ItLooksFamiliar.Core;
using ItLooksFamiliar.Sound;
using UnityEngine;

namespace ItLooksFamiliar.Environment
{


    [RequireComponent(typeof(Animator))]
    public class ShipTransition : MonoBehaviour
    {
        [SerializeField]
        private GameObject Player;
        private Animator mAnim;
        // Start is called before the first frame update
        void Start()
        {
            mAnim = GetComponent<Animator>();
        }

        public void StartTransition()
        {
            SoundManager.Instance.PlaySound("PowerUp");
            StartCoroutine(WaitForBoom(8.1f));
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