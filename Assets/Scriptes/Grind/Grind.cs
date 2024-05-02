using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// <summary>
public class Grind : Inventory
{
    #region µ¥Àý
    private static Grind _instance;
    public static Grind Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("Grind").GetComponent<Grind>();
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

