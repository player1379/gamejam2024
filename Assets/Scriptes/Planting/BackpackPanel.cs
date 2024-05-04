using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// <summary>
public class BackpackPanel : Inventory
{
    #region µ¥Àý
    private static BackpackPanel _instance;
    public static BackpackPanel Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("BackpackPanel").GetComponent<BackpackPanel>();
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

