#region

using UnityEngine;

#endregion

namespace Game
{
    public class GameUI : MonoBehaviour
    {
    #region Private Variables

        private int puzzleSpawnIndex;

        [SerializeField]
        private Canvas canvas;

    #endregion

    #region Public Methods

        public void SpawnPuzzleUI(GameObject puzzlePrefab)
        {
            var puzzle = Instantiate(puzzlePrefab , canvas.transform);
            if (puzzleSpawnIndex > 0) puzzle.SetActive(false);
            puzzleSpawnIndex++;
        }

    #endregion
    }
}