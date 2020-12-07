using System.Collections;
using System.Collections.Generic;
using ItLooksFamiliar.Environment;
using ItLooksFamiliar.Sound;
using ItLooksFamiliar.UI;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace ItLooksFamiliar.Core
{
    public class UIManager : MonoBehaviour
    {
        public GameObject InventoryUI;
        public GameObject ShipUI;
        public GameObject TransitionCanvas;
        public Animation Animation;
        public GameObject Player;
        public GameObject Ship;


        private static UIManager mInstance;
        public static UIManager Instance { get { return mInstance; } }
        public bool InShipProximity { set; get; }
        public bool LockInventoryControls { set; get; }

        void Start()
        {
            if (mInstance == null) mInstance = this;
            StartCoroutine(ShipJumpIn());
        }

        public void ToggleInventory(CallbackContext ctx)
        {
            if(LockInventoryControls) return;
            bool isActive = InventoryUI.activeSelf;
            InventoryUI.SetActive(!isActive);
        }
        public void ShowInventory()
        {
            InventoryUI.SetActive(true);
        }
        public void ToggleRepairConsole(CallbackContext ctx)
        {
            if(LockInventoryControls) return;
            if (!InShipProximity) return;
            ShipUI.SetActive(!ShipUI.activeSelf);
        }
        public void HideUI()
        {
            InventoryUI.SetActive(false);
            ShipUI.SetActive(false);
        }
        public void HideShipHint()
        {
            StartCoroutine(HideAfterDelay(4f));
        }
        public void InitateWorldTransitino()
        {
            StartCoroutine(JumpToNextWorld(4f));
        }
        private IEnumerator HideAfterDelay(float dealy)
        {
            yield return new WaitForSeconds(dealy);
            HintSystem.Instance.Hide();
            yield return null;
        }
        private IEnumerator JumpToNextWorld(float delay)
        {
            yield return new WaitForSeconds(delay);
            Animator anim = TransitionCanvas.GetComponent<Animator>();
            anim.Play("FadeOut");
            yield return new WaitForSeconds(1f);
            SceneLoader.Instance.LoadNext();
            yield return null;
        }

        private IEnumerator ShipJumpIn()
        {
            yield return new WaitForSeconds(1f);
            SoundManager.Instance.PlaySound("PowerDown");
            yield return new WaitForSeconds(4f);
            Player.SetActive(true);
            Ship.SetActive(true);
            MusicManager.Instance.ContinueMusic();
        }
    }
}