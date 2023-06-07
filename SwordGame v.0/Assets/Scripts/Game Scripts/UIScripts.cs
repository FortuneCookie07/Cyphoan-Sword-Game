using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScripts : MonoBehaviour
{
    private TextMeshProUGUI moneyText;
    // Start is called before the first frame update
    void Start()
    {
        moneyText = GetComponent<TextMeshProUGUI>();

        if (moneyText == null)
            Debug.LogError(("TextMeshProUGUI component not found!"));
    }

    void Update()
    {
        if (moneyText)
            moneyText.text = "Current Money: " + MoneyManager.Instance.GetCurrentMoney();
    }
}
