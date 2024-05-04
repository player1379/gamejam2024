using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// <summary>
public class PlantPanel : Inventory
{
    #region µ¥Àý
    private static PlantPanel _instance;
    public static PlantPanel Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("PlantPanel").GetComponent<PlantPanel>();
            }
            return _instance;
        }
    }
    #endregion

    public override void Start()
    {
        base.Start();
        Show();
    }
}

