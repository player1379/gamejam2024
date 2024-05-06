using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// �䷽���
/// <summary>
public class FormulaPanel : Inventory
{
    #region ����
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

    public override void Start()
    {
        base.Start();
        Hide();
    }
}

