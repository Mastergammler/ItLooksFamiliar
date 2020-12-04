using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ItLooksFamiliar.UI
{

    [RequireComponent(typeof(Image))]
    public class DragDropItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        private Image mImage;
        private RectTransform mTransform;
        private CanvasGroup mCanvasGroup;

        [SerializeField]
        private Canvas ParentCanvas;
        private Vector2 mOriginalPosition;

        //################
        //##    MONO    ##
        //################
        private void Awake()
        {
            mImage = GetComponent<Image>();
            mTransform = GetComponent<RectTransform>();
            mCanvasGroup = GetComponent<CanvasGroup>();
            mOriginalPosition = mTransform.anchoredPosition;
        }
        //#################
        //##  INTERFACE  ##
        //#################
        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!activeItem.Invoke()) return;
            mCanvasGroup.blocksRaycasts = false;
            mCanvasGroup.alpha = 0.6f;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!activeItem.Invoke()) return;
            mTransform.anchoredPosition += eventData.delta / ParentCanvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            //if(!activeItem.Invoke()) return;
            mCanvasGroup.blocksRaycasts = true;
            mCanvasGroup.alpha = 1f;
            mTransform.anchoredPosition = mOriginalPosition;
        }

        Func<bool> activeItem => () => mImage.sprite != null;
    }

}