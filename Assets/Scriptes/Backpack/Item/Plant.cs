using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ֲ����
/// <summary>
public class Plant : Item
{
    public string Element { get; set; }
    public string SideEffect { get; set; }

    public Plant(int id, string name, ItemType type, string des, int capacity, int buyPrice, int sellPrice, string sprite, string element, string sideEffect)
        : base(id, name, type, des, capacity, buyPrice, sellPrice, sprite)
    {
        Element = element;
        SideEffect = sideEffect;
    }

    public string[] GetToolTipSprie()
    {
        return new string[] {Element, SideEffect};
    }
}

