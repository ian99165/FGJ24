#region

using UnityEngine;

#endregion

namespace Game
{
    public class Room : MonoBehaviour
    {
    #region Public Variables

        public Room BottomRoom => bottomRoom;

        public Room LeftRoom  => leftRoom;
        public Room RightRoom => rightRoom;
        public Room TopRoom   => topRoom;

    #endregion

    #region Private Variables

        private Vector3 startPosition;

        [SerializeField]
        private Room leftRoom;

        [SerializeField]
        private Room rightRoom;

        [SerializeField]
        private Room topRoom;

        [SerializeField]
        private Room bottomRoom;

        [SerializeField]
        private RectTransform rectTransform;

    #endregion

    #region Unity events

        private void Awake()
        {
            startPosition = rectTransform.localPosition;
        }

    #endregion

    #region Public Methods

        public void ResetPosition()
        {
            rectTransform.localPosition = startPosition;
        }

        public void SetPositionCenter()
        {
            rectTransform.localPosition = Vector3.zero;
        }

    #endregion
    }
}