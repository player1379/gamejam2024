using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantItem : MonoBehaviour
{
    public Plant plant;
    FarmManage fm;
    // Start is called before the first frame update
    void Start()
    {
        fm = FindObjectOfType<FarmManage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetPlant() {
        fm.SelectPlant(this);
    }
}
