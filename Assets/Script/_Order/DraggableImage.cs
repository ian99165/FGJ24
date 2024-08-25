using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _Order
{
    public class DraggableImage : MonoBehaviour , IDragHandler , IBeginDragHandler , IEndDragHandler
    {
        private RectTransform rectTransform;
        private Image imageSelf;
        public Image orber_1;
        public Image orber_2;
        public Image orber_3;
        public Order order;
        public Vector3 currentPosition;
        public Vector3 startPosition;
        
        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            startPosition= rectTransform.position;
            currentPosition = rectTransform.position;
            imageSelf = GetComponent<Image>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            rectTransform.position = eventData.position;
            
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            imageSelf.raycastTarget = false;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            var rayCastTarget = eventData.pointerCurrentRaycast.gameObject;
            var targetImage = rayCastTarget.GetComponent<Image>();
            if (targetImage == orber_1 || targetImage == orber_2 || targetImage == orber_3)
            {
                // ReSharper disable once SwapViaDeconstruction
                var currentPosition = this.currentPosition;
                var targetDraggableImage = targetImage.GetComponent<DraggableImage>();
                var targetDraggablePosition = targetDraggableImage.currentPosition;
                // 設定為對方的位置
                rectTransform.position  = targetDraggablePosition;
                targetImage.transform.position = currentPosition;
                // 交換對方儲存的Position
                targetDraggableImage.currentPosition = this.currentPosition;
                this.currentPosition = targetDraggablePosition;
            }
            else // 拖曳到空白位置
            {
                rectTransform.position  = currentPosition;
            }
            imageSelf.raycastTarget = true;
            order.OnDragEnd();
        }
    }
}