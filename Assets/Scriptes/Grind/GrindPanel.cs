using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// ÑÐÄ¥Ãæ°å
/// <summary>
public class GrindPanel : MonoBehaviour
{
    public Button grindStartBtn;

    public float Timer;
    public float Times=20f;

    private void Start()
    {
        Timer = 0;
        grindStartBtn.onClick.AddListener(CreateGrind);
    }

    private void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > Times)
        {
            Timer = 0;
            Grind.Instance.Show();
            UIManager.Instance.GrindPanelHide();
        }
    }

    public void CreateGrind()
    {
        Chest.Instance.Hide();
        Grind.Instance.Hide();
        GrindManager.instance.GrindStart();
        GameManager.Instance.GrindGameIsStart =true;
    }
}

