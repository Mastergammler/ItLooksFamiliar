﻿using System;
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
        //##################
        //##    EDITOR    ##
        //##################

        [SerializeField]
        private Canvas ParentCanvas;
        [SerializeField]
        private RectTransform ParentPanel;

        //###############
        //##  MEMBERS  ##
        //###############

        private Image mImage;
        private RectTransform mTransform;
        private CanvasGroup mCanvasGroup;
        private Vector2 mOriginalPosition;
        private Func<bool> activeItem => () => mImage.sprite != null;

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

        //#####################
        //##  DRAG HANDLERS  ##
        //#####################

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!activeItem.Invoke()) return;
            mCanvasGroup.blocksRaycasts = false;
            mCanvasGroup.alpha = 0.6f;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!activeItem.Invoke()) return;
            Vector2 additionalScale = new Vector2(1f,1f);
            if(ParentPanel != null) additionalScale = ParentPanel.localScale;
            mTransform.anchoredPosition += eventData.delta / (ParentCanvas.scaleFactor * additionalScale);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            //if(!activeItem.Invoke()) return;
            mCanvasGroup.blocksRaycasts = true;
            mCanvasGroup.alpha = 1f;
            mTransform.anchoredPosition = mOriginalPosition;
        }
    }

}