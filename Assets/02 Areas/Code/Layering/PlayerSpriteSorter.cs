using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItLooksFamiliar.Layering
{

    public class PlayerSpriteSorter : MonoBehaviour
    {
        //##################
        //##    EDITOR    ##
        //##################

        [Range(-25, 25)]
        public int LayerOffset = 15;

        //###############
        //##  MEMBERS  ##
        //###############

        private SpriteRenderer[] mRend;
        private int[] startingLayers;
        private Transform mFootPosition;

        //################
        //##    MONO    ##
        //################

        void Start()
        {
            mRend = GetComponentsInChildren<SpriteRenderer>();
            mFootPosition = transform.Find("FootPos").transform;
            startingLayers = new int[mRend.Length];

            for (int i = 0; i < mRend.Length; i++)
            {
                startingLayers[i] = mRend[i].sortingOrder;
            }
        }

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < mRend.Length; i++)
            {
                mRend[i].sortingOrder = startingLayers[i] + (int)(mFootPosition.position.y * -100) - LayerOffset;
            }
        }
    }

}