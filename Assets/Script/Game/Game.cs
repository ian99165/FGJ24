#region

using UnityEngine;

#endregion

namespace Game
{
    public class Game : MonoBehaviour
    {
    #region Private Variables

        [SerializeField]
        private bool spotTheDifferences;

        [SerializeField]
        private bool countFinished;

    #endregion

    #region Public Methods

        public void FinishCount()
        {
            countFinished = true;
            GetGameUI().ShowCameo_Count();
            CheckAllGameComplete();
        }

        public void FinishOrder()
        {
            GetGameUI().ShowOrder();
        }

        public void FinishSpotTheDifferences()
        {
            spotTheDifferences = true;
            FindObjectOfType<GameUI>().ShowCameo_S_T_D();
            CheckAllGameComplete();
        }

    #endregion

    #region Private Methods

        private void CheckAllGameComplete()
        {
            if (spotTheDifferences && countFinished)
            {
                Debug.Log("AllGameComplete");
                GetGameUI().ShowGhost();
            }
        }

        private GameUI GetGameUI()
        {
            return FindObjectOfType<GameUI>();
        }

    #endregion
    }
}