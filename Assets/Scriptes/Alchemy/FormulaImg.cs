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

    public Button closeBtn;

    public GameObject prefabWithImage;
    //�ϳ�̨���Ԫ��
    public int[] ElementInt = new int[] { 0, 0, 0, 0, 0 };

    //�䷽��Ҫ��Ԫ��
    public int[] ElementFormul; //{2,2,0,0,0}
    //�䷽����Ҫ��Ԫ��������������Ԥ�Ƽ�
    public List<GameObject> elementsGameObjects;

    private void Update()
    {
        UpdateFormulaImg();
        UpdateAlchemy();
    }

    //�����䷽�е�Ԫ��
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

    //������Ϻ������ʾ
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

