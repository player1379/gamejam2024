using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 
/// <summary>
public class BubbleAmount : MonoBehaviour
{
    int index;
    int MaxIndex = 20;//�ɸĳ����䷽��������

    public Slider Slider;

    private void Start()
    {
        index = 0;
    }

    private void Update()
    {
        Slider.value = (float)index/MaxIndex;
        if (MaxIndex < index)
        {
            //С��Ϸ����  ��ʾ�������  �رմ���
            InventoryManager.Instance.HideBubblePanel();
            InventoryManager.Instance.ShowAllButton();
        }
    }

    public void BubbleCount()
    {
        index++;
    }
}

