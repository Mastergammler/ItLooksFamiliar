using System.Collections;
using System.Collections.Generic;
using ItLooksFamiliar.Core;
using UnityEngine;

namespace ItLooksFamiliar.Environment
{

    public class ProximityTrigger : MonoBehaviour
    {
        [SerializeField]
        private GameObject InteractionElement;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag.Equals("Player"))
            {
                InteractionElement.SetActive(true);
                UIManager.Instance.InShipProximity = true;

            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag.Equals("Player"))
            {
                InteractionElement.SetActive(false);
                UIManager.Instance.InShipProximity = false;
                UIManager.Instance.ShipUI.SetActive(false);
            }
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}