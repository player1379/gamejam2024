using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// ÑÐÄ¥Ãæ°å
/// <summary>
public class GrindPanel : MonoBehaviour
{
    public GameObject sliderObj;
    public GameObject triggerObj;

    public Transform triggerTrans;

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
            UIManager.Instance.GrindPanelHide();
        }
    }

    public void CreateGrind()
    {
        Chest.Instance.Hide();
        Grind.Instance.Hide();
        GrindManager.instance.GrindStart();
        GameObject sObj = Instantiate(sliderObj);
        sObj.transform.SetParent(triggerTrans);
        GameObject tObj = Instantiate(triggerObj);
        tObj.transform.SetParent(triggerTrans);
        tObj.transform.localPosition = new Vector3(Random.Range(-4, 6), 0, 0);
    }
}

