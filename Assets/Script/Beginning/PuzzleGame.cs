#region

using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#endregion

namespace Beginning
{
    public class PuzzleGame : MonoBehaviour
    {
    #region Private Variables

        [SerializeField]
        private Image doorL;

        [SerializeField]
        private Image doorR;

        [SerializeField]
        private Image bg;

        [SerializeField]
        private Image ghost;

    #endregion

    #region Unity events

        private void Start()
        {
            doorL.transform.DOLocalMoveX(-2000 , 2);
            doorR.transform.DOLocalMoveX(2000 , 2).OnComplete(OnDoorMoveEnded);
        }

    #endregion

    #region Private Methods

        private void OnDoorMoveEnded()
        {
            bg.transform.DOScale(3 , 1);
            ghost.transform.DOScale(3 , 1).OnComplete(OnGhostScaleEnded);
        }

        private void OnGhostScaleEnded()
        {
            SceneManager.LoadScene("GameScene");
        }

    #endregion
    }
}