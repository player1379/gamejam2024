using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatePanel : MonoBehaviour
{
    public Transform Plot;
    public Transform PanelUI;
    // Start is called before the first frame update
    void Start()
    {
        GameObject worldCam = GameObject.Find("Main Camera");
        PanelUI.position = worldCam.GetComponent<Camera>().WorldToScreenPoint(Plot.position);
        Debug.Log(Plot.GetComponent<Renderer>().bounds.size.x+"x");
        PanelUI.Translate(new Vector2(Plot.GetComponent<Renderer>().bounds.size.x, -Plot.GetComponent<Renderer>().bounds.size.y));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
