#region

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

#endregion

public class SpotTheDifferences : MonoBehaviour
{
#region Public Variables

    public AudioClip _button;

    public AudioClip _clear;
    public float     duration = 1f;

    public float rotationAngle = 90f;

    public GameObject flaw1_img;
    public GameObject flaw2_img;

    public GameObject parentObject;

#endregion

#region Private Variables

    private bool        flaw1_;
    private bool        flaw2_;
    private AudioSource _audioSource;

    [SerializeField]
    private Button flaw1;

    [SerializeField]
    private Button flaw2;

    [SerializeField]
    private Button cameo_S_T_D;

#endregion

#region Unity events

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        flaw1.onClick.AddListener(() =>
                                  {
                                      if (!flaw1_)
                                      {
                                          ClickFlaw1();
                                          ClickFlaw();
                                          _audioSource.PlayOneShot(_button);
                                      }
                                  });
        flaw2.onClick.AddListener(() =>
                                  {
                                      if (!flaw2_)
                                      {
                                          ClickFlaw2();
                                          ClickFlaw();
                                          _audioSource.PlayOneShot(_button);
                                      }
                                  });
        cameo_S_T_D.onClick.AddListener(backhall_S_T_D);
    }

#endregion

#region Private Methods

    private void backhall_S_T_D()
    {
        if (flaw1_ && flaw2_)
        {
            _audioSource.PlayOneShot(_clear);
            print("back!!!");
            cameo_S_T_D.gameObject.SetActive(false);
            var game = FindObjectOfType<Game.Game>();
            if (game != null) game.FinishSpotTheDifferences();
        }
    }

    private void ClickFlaw()
    {
        if (flaw1_ == true && flaw2_ == true)
        {
            StartCoroutine(SmoothRotation());
        }
    }

    private void ClickFlaw1()
    {
        flaw1_img.SetActive(false);
        flaw1_ = true;
    }

    private void ClickFlaw2()
    {
        flaw2_img.SetActive(false);
        flaw2_ = true;
    }

    private IEnumerator SmoothRotation()
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float step = rotationAngle * Time.deltaTime / duration;
            parentObject.transform.Rotate(0 , 0 , step);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

#endregion
}