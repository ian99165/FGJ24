using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpotTheDifferences : MonoBehaviour
{
    [SerializeField] private Button flaw1;
    [SerializeField] private Button flaw2;
    [SerializeField] private Button cameo_S_T_D;

    private bool flaw1_;
    private bool flaw2_;

    public GameObject flaw1_img;
    public GameObject flaw2_img;
    
    public GameObject parentObject;
    
    public float rotationAngle = 90f;
    public float duration = 1f;
    
    void Start()
    {
        flaw1.onClick.AddListener((() =>
        {
            if (!flaw1_)
            {
                ClickFlaw1();
                ClickFlaw();
            }
        }));
        flaw2.onClick.AddListener((() =>
        {
            if (!flaw2_)
            {
                ClickFlaw2();
                ClickFlaw();
            }
        }));
        cameo_S_T_D.onClick.AddListener(backhall_S_T_D);
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

    private void ClickFlaw()
    {
        if (flaw1_ == true && flaw2_ == true)
        {
            StartCoroutine(SmoothRotation());
        }
    }
    
    private IEnumerator SmoothRotation()
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float step = rotationAngle * Time.deltaTime / duration;
            parentObject.transform.Rotate(0, 0, step);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private void backhall_S_T_D()
    {
        if (flaw1_ == true && flaw2_ == true)
        {
            print("back!!!");
        }
    }
}