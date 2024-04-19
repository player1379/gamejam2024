using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ����̨
/// <summary>
public class Alchemy : Inventory
{ 
    #region ����
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

    //�����Ӧ����  �� ľ ˮ �� ��
    public int[] elementCount;

    //�������
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

    //�Ƿ��пո��ӿ��Է���
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

    //����ϳ�̨���Ԫ���ܺ�  ��1 ľ2 ˮ3 ��4 ��5
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

    //�����ж���Ԫ��
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

