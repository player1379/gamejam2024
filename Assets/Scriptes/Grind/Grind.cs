using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// ÑÐÄ¥Ãæ°å
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

    public Button grindStartBtn;

    public override void Start()
    {
        base.Start();
        Show();
        grindStartBtn.onClick.AddListener(OnGrindStartBtn);
    }

    void OnGrindStartBtn()
    {
        int id;
        if (slotList[0].transform.childCount > 0)
        {
            id = slotList[0].transform.GetChild(0).GetComponent<ItemUI>().Item.ID;
            Chest.Instance.StoreItem(id);
            Chest.Instance.StoreItem(id);
            Destroy(slotList[0].transform.GetChild(0).gameObject);
            GrindManager.instance.GrindStart();

            Chest.Instance.Hide();
            Hide();
        }
    }
}

