using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Count : MonoBehaviour
{
    [SerializeField] private Button button_1;
    [SerializeField] private Button button_2;
    [SerializeField] private Button button_3;
    [SerializeField] private Button button_4;
    [SerializeField] private Button Anubis_;
    [SerializeField] private Button password_;
    [SerializeField] private Button cameo_;
    [SerializeField] private Button Count_Exit;

    public GameObject CountUI;
    public GameObject CountPasswordUI;
    public GameObject CountUI_Exit;
    public bool countWin;

    public int number1;
    public int number2;
    public int number3;
    public int number4;

    public RectTransform buttonRectTransform;

    // Start is called before the first frame update
    void Start()
    {
        button_1.onClick.AddListener((() =>
        {
            number1++;
            if (number1 > 9)
            {
                number1 = 0;
            }

            Debug.Log($"number1: {number1}");
            button_1.GetComponentInChildren<TMP_Text>().text = $"{number1}";
            CheckGameWin();
        }));
        button_2.onClick.AddListener((() =>
        {
            number2++;
            if (number2 > 9)
            {
                number2 = 0;
            }

            Debug.Log($"number2: {number2}");
            button_2.GetComponentInChildren<TMP_Text>().text = $"{number2}";
            CheckGameWin();
        }));
        button_3.onClick.AddListener((() =>
        {
            number3++;
            if (number3 > 9)
            {
                number3 = 0;
            }

            Debug.Log($"number3: {number3}");
            button_3.GetComponentInChildren<TMP_Text>().text = $"{number3}";
            CheckGameWin();
        }));
        button_4.onClick.AddListener((() =>
        {
            number4++;
            if (number4 > 9)
            {
                number4 = 0;
            }

            Debug.Log($"number4: {number4}");
            button_4.GetComponentInChildren<TMP_Text>().text = $"{number4}";
            CheckGameWin();
        }));
        Anubis_.onClick.AddListener(ClickCountuiClick);
        password_.onClick.AddListener(ClickpasswordClick);
        cameo_.onClick.AddListener(backhall);
        Count_Exit.onClick.AddListener(ClickCountuiUIExit);
    }

    private void CheckGameWin()
    {
        if (number1 == 4 && number2 == 1 && number3 == 2 && number4 == 1)
        {
            print("GameWin");
            CountUI.SetActive(false);
            CountUI_Exit.SetActive(false);
            countWin = true;
            movecountUI();
        }
    }

    private void ClickCountuiClick()
    {
        if (countWin == false)
        {
            CountUI.SetActive(true);
            CountUI_Exit.SetActive(true);
        }
    }

    private void ClickCountuiUIExit()
    {
        CountPasswordUI.SetActive(false);
        CountUI.SetActive(false);
        CountUI_Exit.SetActive(false);
    }

    private void ClickpasswordClick()
    {
        if (countWin == false)
        {
            CountPasswordUI.SetActive(true);
            CountUI_Exit.SetActive(true);
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

    private void backhall()
    {
        print("back!!!");
    }
}