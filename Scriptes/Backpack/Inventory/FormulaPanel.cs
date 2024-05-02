using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Åä·½Ãæ°å
/// <summary>
public class FormulaPanel : Inventory
{
    #region µ¥Àý
    private static FormulaPanel _instance;
    public static FormulaPanel Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("FormulaPanel").GetComponent<FormulaPanel>();
            }
            return _instance;
        }
    }
    #endregion
}

