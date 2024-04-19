using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ҩˮ��
/// <summary>
public class Medicamen : Item
{
    public string SideEffect { get; set; }

    public Medicamen(int id, string name, ItemType type, string des, int capacity, int buyPrice, int sellPrice, string sprite,string sideEffect)
        : base(id, name, type, des, capacity, buyPrice, sellPrice, sprite)
    {
        SideEffect = sideEffect;
    }
}

