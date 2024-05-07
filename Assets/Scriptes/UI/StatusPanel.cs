using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusPanel : MonoBehaviour
{
    public Text moneyText;
    public Text dayText;
    public Slider FTG;
    public Text FTGText;
    public Slider MP;

    void Update()
    {
        dayText.text = GameManager.Instance.Day.ToString();
        FTG.value = GameManager.Instance.FTG / 10f;
        FTGText.text = GameManager.Instance.FTG + "/10";
    }
}
