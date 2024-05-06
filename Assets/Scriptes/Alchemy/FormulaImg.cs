using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 管理配方里元素的满足情况
/// <summary>
public class FormulaImg : MonoBehaviour
{
    public GameObject[] Elements;

    public Button closeBtn;

    public GameObject prefabWithImage;
    //合成台里的元素
    public int[] ElementInt = new int[] { 0, 0, 0, 0, 0 };

    //配方需要的元素
    public int[] ElementFormul; //{2,2,0,0,0}
    //配方里需要的元素所创建的所有预制件
    public List<GameObject> elementsGameObjects;

    private void Update()
    {
        UpdateFormulaImg();
        UpdateAlchemy();
    }

    //更新配方中的元素
    public void UpdateFormulaImg()
    {
        ElementFormul = ConvertToNumberArray(InventoryManager.Instance.formulaesStr);
        Color c = Color.black;
        c.a = 0;
        Color c2 = Color.black;
        for (int i = 0; i < Elements.Length; i++)
        {
            for (int j = 0; j < Elements[i].transform.childCount; j++)
            {
                Elements[i].transform.GetChild(j).GetComponent<Image>().color = c;
            }
            for (int k = 0; k < ElementFormul[i]; k++)
            {
                Elements[i].transform.GetChild(k).GetComponent<Image>().color = c2;
            }
        }
    }

    //放入材料后更新显示
    public void UpdateAlchemy()
    {
        Color c = Color.white;
        ElementInt = InventoryManager.Instance.alchemyInt;
        for (int i = 0; i < ElementInt.Length; i++)
        {
            for (int k = 0; k < ElementInt[i]; k++)
            {
                Elements[i].transform.GetChild(k).GetComponent<Image>().color = c;
            }
        }
        
        for (int i = 0; i < ElementInt.Length; i++)
        {
            if (ElementInt[i] < ElementFormul[i])
            {
                Alchemy.Instance.HideAlchemyBtn();
                return;
            }
        }
        Alchemy.Instance.ShowAlchemyBtn();
    }


    //字符串->数组
    public static int[] ConvertToNumberArray(string str)
    {
        int[] result = new int[str.Length];
        for (int i = 0; i < str.Length; i++)
        {
            if (char.IsDigit(str[i])) // 确保当前字符是数字
            {
                result[i] = int.Parse(str[i].ToString());
            }
            else
            {
                throw new FormatException("输入字符串包含非数字字符。");
            }
        }
        return result;
    }
}

