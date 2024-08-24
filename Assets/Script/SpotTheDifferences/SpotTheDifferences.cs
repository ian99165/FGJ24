using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpotTheDifferences : MonoBehaviour
{
    [SerializeField] private Button flaw1;
    [SerializeField] private Button flaw2;
    [SerializeField] private Button flaw3;
    [SerializeField] private Button cameo_S_T_D;

    private bool flaw1_;
    private bool flaw2_;
    private bool flaw3_;

    public GameObject flaw1_img;
    public GameObject flaw2_img;
    public GameObject flaw3_img;

    public RectTransform buttonRectTransform;
    
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
        flaw3.onClick.AddListener((() =>
        {
            if (!flaw3_)
            {
                ClickFlaw3();
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

    private void ClickFlaw3()
    {
        flaw3_img.SetActive(false);
        flaw3_ = true;
    }

    private void ClickFlaw()
    {
        if (flaw1_ == true && flaw2_ == true && flaw3_ == true)
        {
            movecountUI();
        }
    }

    private void movecountUI()
    {
        StartCoroutine(SmoothMoveUI(new Vector2(0, 50), 1f));
    }

    private IEnumerator SmoothMoveUI(Vector2 moveAmount, float duration)
    {
        Vector2 startPosition = buttonRectTransform.anchoredPosition;
        Vector2 targetPosition = startPosition + moveAmount;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            buttonRectTransform.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        buttonRectTransform.anchoredPosition = targetPosition;
    }
    
    private void backhall_S_T_D()
    {
        print("back!!!");
    }
}