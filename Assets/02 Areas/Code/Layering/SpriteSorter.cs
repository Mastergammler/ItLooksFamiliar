using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItLooksFamiliar.Layering
{

    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteSorter : MonoBehaviour
    {
        public int BoxOffset = 0;
        private SpriteRenderer mRend;
        void Start()
        {
            mRend = GetComponent<SpriteRenderer>();
                                                                                      //because bounds.min is negative 
            mRend.sortingOrder = (int)(transform.position.y * -100) + (int)(mRend.sprite.bounds.min.y * -100) - BoxOffset;
             Debug.Log(mRend.sprite.bounds.min.y);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}