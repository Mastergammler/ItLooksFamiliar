using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItLooksFamiliar.Environment
{

    public class SpriteLayering : MonoBehaviour
    {
        private SpriteRenderer mRenderer;

        void Start()
        {
            mRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag.Equals("Player"))
            {
                mRenderer.sortingLayerName = "BeforePlayer";
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag.Equals("Player"))
            {
                mRenderer.sortingLayerName = "BehindPlayer";
            }
        }
    }

}