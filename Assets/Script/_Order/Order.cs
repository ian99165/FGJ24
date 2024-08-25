#region

using UnityEngine;
using UnityEngine.UI;

#endregion

namespace _Order
{
    public class Order : MonoBehaviour
    {
    #region Public Variables

        public AudioClip _button;

        public AudioClip _clear;

        public Button         orber_1_B;
        public Button         orber_2_B;
        public Button         orber_3_B;
        public DraggableImage orber_1;
        public DraggableImage orber_2;
        public DraggableImage orber_3;

    #endregion

    #region Private Variables

        private AudioSource _audioSource;

    #endregion

    #region Unity events

        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            orber_1_B.onClick.AddListener(audio__);
            orber_2_B.onClick.AddListener(audio__);
            orber_3_B.onClick.AddListener(audio__);
        }

    #endregion

    #region Public Methods

        public void audio__()
        {
            _audioSource.PlayOneShot(_button);
        }

        public void OnDragEnd()
        {
            var orber1Finished = orber_1.currentPosition == orber_2.startPosition;
            var orber2Finished = orber_2.currentPosition == orber_3.startPosition;
            var orber3Finished = orber_3.currentPosition == orber_1.startPosition;
            var gamefinished   = orber1Finished && orber2Finished && orber3Finished;
            if (gamefinished)
            {
                print("過關");
                _audioSource.PlayOneShot(_clear);
                var game = FindObjectOfType<Game.Game>();
                if (game != null) game.FinishOrder();
            }
        }

    #endregion
    }
}