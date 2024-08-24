#region

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#endregion

namespace Beginning
{
    public class SwitchToGameScene : MonoBehaviour
    {
    #region Private Variables

        [SerializeField]
        private Button button;

    #endregion

    #region Unity events

        private void Awake()
        {
            button.onClick.AddListener(ChangeScene);
        }

    #endregion

    #region Private Methods

        private void ChangeScene()
        {
            SceneManager.LoadScene("GameScnee");
        }

    #endregion
    }
}