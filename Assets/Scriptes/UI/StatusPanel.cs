using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusPanel : MonoBehaviour
{
    private TextMeshProUGUI moneyText;
    private TextMeshProUGUI dayText;
    private TextMeshProUGUI MoneyText
    {
        get
        {
            if (moneyText == null)
            {
                moneyText = GetComponentInChildren<TextMeshProUGUI>();
            }
            return moneyText;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        MoneyText.text = "1111";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
