using System.Collections;
using System.Collections.Generic;
using MgSq.UI;
using UnityEngine;

public class HintSystem : MonoBehaviour
{
        private static HintSystem mInstance;
        public static HintSystem Instance { get { return mInstance; }}

        public StaticTooltip Tooltip;

        private void Awake() 
        {
            mInstance = this;
        }

        public void Show(string content,string header = "")
        {
            mInstance.Tooltip.SetText(content,header);
            mInstance.Tooltip.gameObject.SetActive(true);
        }
        public void Hide()
        {
            mInstance.Tooltip.gameObject.SetActive(false);
        }
}
