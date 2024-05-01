using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ÑÐÄ¥Ãæ°å
/// <summary>
public class GrindPanel : MonoBehaviour
{
    public GameObject sliderObj;
    public GameObject triggerObj;

    public Transform triggerTrans;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            CreateGrind();
        }
    }

    public void CreateGrind()
    {
        GameObject sObj = Instantiate(sliderObj);
        sObj.transform.SetParent(triggerTrans);
        GameObject tObj = Instantiate(triggerObj);
        tObj.transform.SetParent(triggerTrans);
        tObj.transform.localPosition = new Vector3(Random.Range(-4, 6), 0, 0);
    }
}

