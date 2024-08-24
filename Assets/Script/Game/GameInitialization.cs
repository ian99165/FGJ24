#region

using UnityEngine;

#endregion

namespace Game
{
    public class GameInitialization : MonoBehaviour
    {
    #region Private Variables

        [SerializeField]
        private GameUI gameUIPrefab;

    #endregion

    #region Unity events

        private void Awake()
        {
            Instantiate(gameUIPrefab);
        }

    #endregion
    }
}