#region

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#endregion

namespace _Order
{
    public class DraggableImage : MonoBehaviour , IDragHandler , IBeginDragHandler , IEndDragHandler
    {
    #region Public Variables

        public Vector3   startPosition => originImage.position;
        public Image     orber_1;
        public Image     orber_2;
        public Image     orber_3;
        public Order     order;
        public Transform originImage;
        public Vector3   currentPosition;

    #endregion

    #region Private Variables

        private RectTransform rectTransform;
        private Image         imageSelf;

    #endregion

    #region Unity events

        private void Start()
        {
            rectTransform   = GetComponent<RectTransform>();
            imageSelf       = GetComponent<Image>();
            currentPosition = startPosition;
        }

    #endregion

    #region Public Methods

        public void OnBeginDrag(PointerEventData eventData)
        {
            imageSelf.raycastTarget = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            rectTransform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            var rayCastTarget = eventData.pointerCurrentRaycast.gameObject;
            var targetImage   = rayCastTarget.GetComponent<Image>();
            if (targetImage == orber_1 || targetImage == orber_2 || targetImage == orber_3)
            {
                // ReSharper disable once SwapViaDeconstruction
                var targetDraggableImage    = targetImage.GetComponent<DraggableImage>();
                var targetDraggablePosition = targetDraggableImage.startPosition;

                // 設定為對方的位置
                rectTransform.position         = targetDraggablePosition;
                targetImage.transform.position = currentPosition;
                // 交換對方儲存的Position
                currentPosition                      = targetDraggableImage.currentPosition;
                targetDraggableImage.currentPosition = startPosition;
            }
            else // 拖曳到空白位置
            {
                rectTransform.position = startPosition;
            }

            imageSelf.raycastTarget = true;
            order.OnDragEnd();
        }

    #endregion
    }
}