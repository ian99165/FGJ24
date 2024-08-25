#region

using UnityEngine;
using UnityEngine.EventSystems;

#endregion

namespace Beginning
{
    public class DraggablePuzzle : MonoBehaviour , IDragHandler , IEndDragHandler , IBeginDragHandler
    {
    #region Private Variables

        private RectTransform rectTransform;

    #endregion

    #region Unity events

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
        }

    #endregion

    #region Public Methods

        public void OnBeginDrag(PointerEventData eventData)
        {
            rectTransform.SetAsLastSibling();
        }

        public void OnDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition += eventData.delta * 2;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log($"{eventData.pointerCurrentRaycast.gameObject}");
        }

    #endregion
    }
}