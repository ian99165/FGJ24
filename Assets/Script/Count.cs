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

    public int number1;
    public int number2;
    public int number3;
    public int number4;
    // Start is called before the first frame update
    void Start()
    {
        button_1.onClick.AddListener((() =>
        {
            number1++;
            if (number1>9) number1 = 0;
            Debug.Log($"number1: {number1}");
            button_1.GetComponentInChildren<TMP_Text>().text = $"{number1}";
            CheckGameWin();
        }));
        button_2.onClick.AddListener((() =>
        {
            number2++;
            if (number2>9) number2 = 0;
            Debug.Log($"number2: {number2}");
            button_2.GetComponentInChildren<TMP_Text>().text = $"{number2}";
            CheckGameWin();
        }));
        button_3.onClick.AddListener((() =>
        {
            number3++;
            if (number3>9) number3 = 0;
            Debug.Log($"number3: {number3}");
            button_3.GetComponentInChildren<TMP_Text>().text = $"{number3}";
            CheckGameWin();
        }));
        button_4.onClick.AddListener((() =>
        {
            number4++;
            if (number4>9) number4 = 0;
            Debug.Log($"number4: {number4}");
            button_4.GetComponentInChildren<TMP_Text>().text = $"{number4}";
            CheckGameWin();
        }));
        
        
    }

    private void CheckGameWin()
    {
        if (number1 == 4 && number2 == 1 && number3== 2 && number4 == 1)
        {
           print("GameWin"); 
        }
    }
}
