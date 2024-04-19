using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// Åä·½¸ñ×Ó
/// <summary>
public class FormulaSlot : Slot
{
    public override void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (InventoryManager.Instance.IsPickedItem == false && transform.childCount > 0)
            {
                ItemUI currentItemUI = transform.GetChild(0).GetComponent<ItemUI>();
                Formulaes currentItem = (Formulaes)currentItemUI.Item;

                InventoryManager.Instance.ShowFormula(currentItem);
            }
        }
    }
}
