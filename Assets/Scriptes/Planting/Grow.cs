using UnityEngine;
using System.Collections;

public class Grow : Inventory
{
    private static Grow _instance;
    public static Grow Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("GrowPanel").GetComponent<Grow>();
            }
            return _instance;
        }
    }

    public override void Start()
    {
        base.Start();
        Hide();
    }
}
