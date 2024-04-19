using UnityEngine;
using System.Collections;

/// <summary>
/// 材料类
/// </summary>
public class Material : Item 
{
    public string Element { get; set; }
    public string SideEffect { get; set; }

    public Material(int id, string name, ItemType type, string des, int capacity, int buyPrice, int sellPrice,string sprite, string element, string sideEffect)
        : base(id, name, type, des, capacity, buyPrice, sellPrice, sprite)
    {
        Element = element;
        SideEffect = sideEffect;
    }


}
