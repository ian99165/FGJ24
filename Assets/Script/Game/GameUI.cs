#region

using UnityEngine;
using UnityEngine.UI;

#endregion

namespace Game
{
    public class GameUI : MonoBehaviour
    {
    #region Private Variables

        private int puzzleSpawnIndex;

        private int currentPuzzleIndex;

        private Room currentRoom;

        [SerializeField]
        private Room startRoom;

        [SerializeField]
        private Button buttonLeft;

        [SerializeField]
        private Button buttonRight;

        [SerializeField]
        private Button buttonTop;

        [SerializeField]
        private Button buttonBottom;

    #endregion

    #region Unity events

        private void Awake()
        {
            buttonLeft.onClick.AddListener(SwitchToLeft);
            buttonRight.onClick.AddListener(SwitchToRight);
            buttonTop.onClick.AddListener(SwitchToTop);
            buttonBottom.onClick.AddListener(SwitchToBottom);
            buttonBottom.gameObject.SetActive(false);
            currentRoom = startRoom;
        }

    #endregion

    #region Private Methods

        private void RefreshButtons()
        {
            SetGameObjectActive(buttonLeft ,   currentRoom.LeftRoom != null);
            SetGameObjectActive(buttonRight ,  currentRoom.RightRoom != null);
            SetGameObjectActive(buttonTop ,    currentRoom.TopRoom != null);
            SetGameObjectActive(buttonBottom , currentRoom.BottomRoom != null);
        }

        private void SetGameObjectActive(Component component , bool active)
        {
            component.gameObject.SetActive(active);
        }

        private void SwitchToBottom()
        {
            if (currentRoom.BottomRoom == null) return;
            currentRoom.ResetPosition();
            currentRoom = currentRoom.BottomRoom;
            currentRoom.SetPositionCenter();
            RefreshButtons();
        }

        private void SwitchToLeft()
        {
            if (currentRoom.LeftRoom == null) return;
            currentRoom.ResetPosition();
            currentRoom = currentRoom.LeftRoom;
            RefreshButtons();
            currentRoom.SetPositionCenter();
        }

        private void SwitchToRight()
        {
            if (currentRoom.RightRoom == null) return;
            currentRoom.ResetPosition();
            currentRoom = currentRoom.RightRoom;
            currentRoom.SetPositionCenter();
            RefreshButtons();
        }

        private void SwitchToTop()
        {
            if (currentRoom.TopRoom == null) return;
            currentRoom.TopRoom.SetPositionCenter();
            currentRoom = currentRoom.TopRoom;
            RefreshButtons();
        }

    #endregion
    }
}