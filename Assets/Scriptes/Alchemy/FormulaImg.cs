using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// �����䷽��Ԫ�ص��������
/// <summary>
public class FormulaImg : MonoBehaviour
{
    public GameObject[] Elements;
    public Sprite[] elements;

    public GameObject prefabWithImage;
    //�ϳ�̨���Ԫ��
    public int[] ElementInt = new int[] { 0, 0, 0, 0, 0 };

    //�䷽��Ҫ��Ԫ��
    public int[] ElementFormul;
    //�䷽����Ҫ��Ԫ��������������Ԥ�Ƽ�
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

    //�����䷽�е�Ԫ��
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

    //������Ϻ������ʾ
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
                Debug.Log("���ܺϳ�");
                return;
            }
        }
        Debug.Log("���Ժϳ�");
    }

    //�ַ���->����
    public static int[] ConvertToNumberArray(string str)
    {
        int[] result = new int[str.Length];
        for (int i = 0; i < str.Length; i++)
        {
            if (char.IsDigit(str[i])) // ȷ����ǰ�ַ�������
            {
                result[i] = int.Parse(str[i].ToString());
            }
            else
            {
                throw new FormatException("�����ַ��������������ַ���");
            }
        }
        return result;
    }
}

