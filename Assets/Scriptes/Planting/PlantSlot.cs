using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// 
/// <summary>
public class PlantSlot : Slot
{
    public GorwthTip gorwthTip;

    private void Start()
    {
        gorwthTip = FindObjectOfType<GorwthTip>();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        //右键收获
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (transform.childCount > 0)
            {
                ItemUI currentItem = transform.GetChild(0).GetComponent<ItemUI>();
                Plant plant = currentItem.Item as Plant;
                if (!plant.CanPlant)
                {
                    Debug.Log(currentItem.Item.ID);
                    Chest.Instance.StoreItem(currentItem.Item.ID);
                    DestroyImmediate(currentItem.gameObject);

                    //隐藏提示面板
                }
                else
                {
                    Debug.Log("这个植物不可以收获");
                }
            }
        }
        //手上有东西 地上没东西  种植
        //手上没东西 地上有东西  打开GorwthTip
        //手上有东西 地上也有东西 TODO 判断是否可交互(暂时不做)
        if (eventData.button != PointerEventData.InputButton.Left) return;
        if (transform.childCount > 0) //地上有东西
        {
            ItemUI currentItem = transform.GetChild(0).GetComponent<ItemUI>();
            if (InventoryManager.Instance.IsPickedItem ==false) //手上没东西
            {
                gorwthTip.Show(currentItem.Item.Name);

                gorwthTip.itemUI = currentItem;
                
                gorwthTip.SetLocalPotion(new Vector3(transform.localPosition.x + 180,transform.localPosition.y+60));
            }
            else  //手上有东西  无操作
            {
                return;
            }
        }
        else //地上没东西
        {
            if (InventoryManager.Instance.IsPickedItem)  //手上有东西
            {
                Plant plant = InventoryManager.Instance.PickedItem.Item as Plant;
                if (InventoryManager.Instance.PickedItem.Item.Type == Item.ItemType.Plant && plant.CanPlant)
                {
                    for (int i = 0; i < InventoryManager.Instance.PickedItem.Amount; i++)
                    {
                        StoreItem(InventoryManager.Instance.PickedItem.Item);
                    }
                    InventoryManager.Instance.RemoveItem(InventoryManager.Instance.PickedItem.Amount);
                }
            }
            else
            {
                return; //手上没东西
            }
        }
    }
}

