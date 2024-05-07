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
    public Slider MP;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dayText.text = GameManager.Instance.Day.ToString();
    }
}
