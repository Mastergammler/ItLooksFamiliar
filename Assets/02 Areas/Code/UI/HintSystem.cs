using System.Collections;
using System.Collections.Generic;
using MgSq.UI;
using UnityEngine;

namespace ItLooksFamiliar.UI
{

    public class HintSystem : MonoBehaviour
    {
        //##################
        //##    EDITOR    ##
        //##################

        public StaticTooltip Tooltip;

        //###############
        //##  MEMBERS  ##
        //###############

        private static HintSystem sInstance;

        //################
        //##    MONO    ##
        //################

        private void Awake()
        {
            sInstance = this;
        }

        //#################
        //##  INTERFACE  ##
        //#################

        public void Show(string content, string header = "")
        {
            sInstance.Tooltip.SetText(content, header);
            sInstance.Tooltip.gameObject.SetActive(true);
        }
        public void Hide()
        {
            sInstance.Tooltip.gameObject.SetActive(false);
        }

        //#################
        //##  ACCESSORS  ##
        //#################

        public static HintSystem Instance => sInstance; 
    }

}