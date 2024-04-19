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
    public Sprite[] elements;

    public GameObject prefabWithImage;
    //合成台里的元素
    public int[] ElementInt = new int[] { 0, 0, 0, 0, 0 };

    //配方需要的元素
    public int[] ElementFormul;
    //配方里需要的元素所创建的所有预制件
    public List<GameObject> elementsGameObjects;

    private void Start()
    {
        UpdateFormulaImg();
    }

    private void Update()
    {
        //Debug.Log(ElementInt[0]+","+ElementInt[1] + "," + ElementInt[2] + "," + ElementInt[3] + "," + ElementInt[4]);
        //UpdateFormulaImg();
        //UpdateAlchemy();
    }

    //更新配方中的元素
    public void UpdateFormulaImg()
    {    
        ElementFormul = ConvertToNumberArray(InventoryManager.Instance.formulaesStr);
        for (int i = 0; i < Elements.Length; i++)
        {
            prefabWithImage.GetComponent<Image>().sprite = elements[i];
            prefabWithImage.GetComponent<Image>().color = Color.black;
            for (int j = 0; j < ElementFormul[i]; j++)
            {
                GameObject childObject = Instantiate(prefabWithImage);
                elementsGameObjects.Add(childObject);
                childObject.transform.SetParent(Elements[i].transform);
            }
        }       
    }

    //放入材料后更新显示
    public void UpdateAlchemy()
    {       
        foreach (var item in elementsGameObjects)
        {
            item.GetComponent<Image>().color = Color.black;
        }
        if (InventoryManager.Instance.alchemyInt.Length != 0)
        {
            ElementInt = InventoryManager.Instance.alchemyInt;
        }
        for (int i = 0; i < 5; i++)
        {
            if (ElementInt[i] > ElementFormul[i])
            {
                ElementInt[i] = ElementFormul[i];
            }
            for (int j = 0; j < ElementInt[i]; j++)
            {
                if (Elements[i].transform.GetChild(j) != null)
                {
                    Elements[i].transform.GetChild(j).GetComponent<Image>().color = Color.white;
                }
            }           
        }
        foreach (var item in elementsGameObjects)
        {
            if (item.GetComponent<Image>().color != Color.white)
            {
                Debug.Log("不能合成");
                return;
            }
        }
        Debug.Log("可以合成");
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

