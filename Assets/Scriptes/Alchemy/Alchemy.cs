using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
        foreach(Slot slot in slotList) 
        {
            if (slot.transform.childCount > 0)
            {
                Material item = (Material)slot.transform.GetChild(0).GetComponent<ItemUI>().Item;
                element += item.Element;
                //Debug.Log(element);
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
    public static int CountElement(string inputString, char character)
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

}

