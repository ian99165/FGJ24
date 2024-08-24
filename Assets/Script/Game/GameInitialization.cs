#region

using System.Collections.Generic;
using UnityEngine;

#endregion

namespace Game
{
    public class GameInitialization : MonoBehaviour
    {
    #region Private Variables

        [SerializeField]
        private GameUI gameUIPrefab;

        [SerializeField]
        private List<GameObject> puzzlePrefabs;

    #endregion

    #region Unity events

        private void Awake()
        {
            var gameUI = Instantiate(gameUIPrefab);
            foreach (var puzzlePrefab in puzzlePrefabs) gameUI.SpawnPuzzleUI(puzzlePrefab);
        }

    #endregion
    }
}