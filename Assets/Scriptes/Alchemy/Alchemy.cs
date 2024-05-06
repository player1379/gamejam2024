using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 炼金台
/// <summary>
public class Alchemy : Inventory
{ 
    #region 单例
    private static Alchemy _instance;
    public static Alchemy Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("AlchemyPanel").GetComponent<Alchemy>();
            }
            return _instance;
        }
    }
    #endregion

    public override void Start()
    {
        base.Start();
        Show();
        alchemyBtn.onClick.AddListener(OnAlchemyBtnDown);
        alchemyBtn.gameObject.SetActive(false);
    }

    public Button alchemyBtn;
    public Slider alchemySlider;

    //数组对应数量  金 木 水 火 土
    public int[] elementCount;

    //放入材料
    public void PutInMaterial(Item item)
    {
        foreach (Slot slot in slotList)
        {
            if (slot.transform.childCount == 0)
            {
                AlchemySlot alchemySlot = (AlchemySlot)slot;
                alchemySlot.StoreItem(item);
                return;
            }
        }
    }

    //是否有空格子可以放入
    public bool IsCanPutIn()
    {
        foreach (Slot slot in slotList)
        {
            if (slot.transform.childCount == 0)
            {
                return true;
            }            
        }
        return false;
    }

    //计算合成台里各元素总和  金1 木2 水3 火4 土5
    public int[] CalculateElement()
    {
        string element = "";
        elementCount = elementCount = new int[] { 0, 0, 0, 0, 0 };
        foreach (Slot slot in slotList) 
        {
            if (slot.transform.childCount > 0)
            {
                Item item = slot.transform.GetChild(0).GetComponent<ItemUI>().Item;
                switch (item.Type)
                {
                    case Item.ItemType.Plant:
                        Plant plant = (Plant)item;
                        element += plant.Element;
                        break;
                    case Item.ItemType.Material:
                        Material material = (Material)item;
                        element += material.Element;
                        break;
                }
            }
        }
        if (element != "")
        {
            for (char c = '1'; c <= '5'; c++)
            {
                elementCount[c - '1'] = CountElement(element, c);
            }
        }
        return elementCount;
    }

    //计算有多少元素
    public int CountElement(string inputString, char character)
    {
        int count = 0;
        foreach (char c in inputString)
        {
            if (c == character)
            {
                count++;
            }
        }
        return count;
    }

    //输出一个词条
    public string CalculateEffect()
    {
        foreach (Slot slot in slotList)
        {

        }
        return "";
    }

    //显示可以合成按钮
    public void ShowAlchemyBtn()
    {
        alchemyBtn.gameObject.SetActive(true);
    }

    public void HideAlchemyBtn()
    {
        alchemyBtn.gameObject.SetActive(false);
    }

    //按下合成按钮
    public void OnAlchemyBtnDown()
    {
        //显示气泡玩法界面  输出成品  销毁合成栏的道具
        Chest.Instance.Hide();
        Alchemy.Instance.Hide();
        FormulaPanel.Instance.Hide();
        ClearItem();
        Alchemy.Instance.HideAlchemyBtn();
        alchemySlider.gameObject.SetActive(true);
        GameManager.Instance.BubbleGameIsStart = true;
        Chest.Instance.StoreItem(InventoryManager.Instance.formulaesIndex);
    }

    //清空合成台
    public void ClearItem()
    {
        foreach (Slot slot in slotList)
        {
            if (slot.transform.childCount > 0)
            {
                Destroy(slot.transform.GetChild(0).gameObject);
                InventoryManager.Instance.alchemyInt = new int[] { 0, 0, 0, 0, 0 };
            }
        }
    }
}

