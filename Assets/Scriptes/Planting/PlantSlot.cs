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
        //�Ҽ��ջ�
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

                    //������ʾ���
                }
                else
                {
                    Debug.Log("���ֲ�ﲻ�����ջ�");
                }
            }
        }
        //�����ж��� ����û����  ��ֲ
        //����û���� �����ж���  ��GorwthTip
        //�����ж��� ����Ҳ�ж��� TODO �ж��Ƿ�ɽ���(��ʱ����)
        if (eventData.button != PointerEventData.InputButton.Left) return;
        if (transform.childCount > 0) //�����ж���
        {
            ItemUI currentItem = transform.GetChild(0).GetComponent<ItemUI>();
            if (InventoryManager.Instance.IsPickedItem ==false) //����û����
            {
                gorwthTip.Show(currentItem.Item.Name);

                gorwthTip.itemUI = currentItem;
                
                gorwthTip.SetLocalPotion(new Vector3(transform.localPosition.x + 180,transform.localPosition.y+60));
            }
            else  //�����ж���  �޲���
            {
                return;
            }
        }
        else //����û����
        {
            if (InventoryManager.Instance.IsPickedItem)  //�����ж���
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
                return; //����û����
            }
        }
    }
}

