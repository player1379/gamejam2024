using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



/// <summary>
/// 炼金台格子
/// <summary>
public class AlchemySlot : Slot
{
    public override void StoreItem(Item item)
    {
        GameObject itemGameObject = Instantiate(itemPrefab);
        itemGameObject.transform.SetParent(this.transform);
        itemGameObject.transform.localScale = Vector3.one;
        itemGameObject.transform.localPosition = Vector3.zero;
        itemGameObject.GetComponent<ItemUI>().SetItem(item);
    }

    public override void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (InventoryManager.Instance.IsPickedItem == false && transform.childCount > 0)
            {
                ItemUI currentItemUI = transform.GetChild(0).GetComponent<ItemUI>();               
                Item currentItem = currentItemUI.Item;
                currentItemUI.ReduceAmount(1);
                if (currentItemUI.Amount <= 0)
                {
                    DestroyImmediate(currentItemUI.gameObject);
                    InventoryManager.Instance.HideToolTip();
                }
                Chest.Instance.StoreItem(currentItem);
                InventoryManager.Instance.alchemyInt = Alchemy.Instance.CalculateElement();
                InventoryManager.Instance.UpdataFormula();
            }
        }
    }
}

