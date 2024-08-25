using UnityEngine;
using UnityEngine.UI;

namespace _Order
{
    public class Order : MonoBehaviour
    {
        public DraggableImage orber_1;
        public DraggableImage orber_2;
        public DraggableImage orber_3;

        public Button orber_1_B;
        public Button orber_2_B;
        public Button orber_3_B;

        public AudioClip _clear;
        public AudioClip _button;
        AudioSource _audioSource;
        
        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            orber_1_B.onClick.AddListener(audio__);
            orber_2_B.onClick.AddListener(audio__);
            orber_3_B.onClick.AddListener(audio__);
        }

        public void audio__()
        {
            _audioSource.PlayOneShot(_button);
        }

        public void OnDragEnd()
        {
            var orber1Finished = orber_1.currentPosition == orber_2.startPosition;
            var orber2Finished = orber_2.currentPosition == orber_3.startPosition;
            var orber3Finished = orber_3.currentPosition == orber_1.startPosition;
            var gamefinished = orber1Finished && orber2Finished && orber3Finished;
            if (gamefinished)
            {
                print("過關");
                _audioSource.PlayOneShot(_clear);
            }
        }
    }
}
