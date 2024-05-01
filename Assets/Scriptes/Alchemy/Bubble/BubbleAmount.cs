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
    int MaxIndex = 20;//可改成由配方决定数量

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
            //小游戏结束  显示炼金产物  关闭窗口
            InventoryManager.Instance.HideBubblePanel();
            InventoryManager.Instance.ShowAllButton();
        }
    }

    public void BubbleCount()
    {
        index++;
    }
}

