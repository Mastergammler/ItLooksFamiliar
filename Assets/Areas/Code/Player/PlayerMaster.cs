using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ItLooksFamiliar.Items
{

    public class PlayerMaster : MonoBehaviour
    {


        private IMoveable mMovement;
        private IInventory mInventory;
        private AudioSource mAudioSource;
        // Start is called before the first frame update
        void Start()
        {
            mMovement = GetComponent<IMoveable>();
            mInventory = GetComponent<IInventory>();
            mAudioSource = GetComponent<AudioSource>();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            Vector2 moveVal = context.ReadValue<Vector2>();
            mMovement.Move(moveVal);
            //Debug.Log("Recieved movement input " + moveVal);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void OnTriggerEnter2D(Collider2D other)
        {
            ICollectable col = other.GetComponent<ICollectable>();
            if (col != null)
            {
                CollectableSO so = col.OnCollect();
                if (so == null) return;
                if (mInventory.AddItem(so))
                {
                    mAudioSource.Play();
                    Destroy(other.gameObject);
                }
            }
        }
    }
}