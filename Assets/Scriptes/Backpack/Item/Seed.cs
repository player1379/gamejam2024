using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ÷÷◊”¿‡
/// <summary>
public class Seed : Item
{
    public string Element { get; set; }
    public int Elementamount { get; set; }
    public string SideEffect { get; set; }

    public float Growthtime { get; set; }

    public Seed(int id, string name, ItemType type, string des, int capacity, int buyPrice, int sellPrice, string sprite, string element, int elementamount, string sideEffect, float growthtime)
        : base(id, name, type, des, capacity, buyPrice, sellPrice, sprite)
    {
        Element = element;
        Elementamount = elementamount;
        SideEffect = sideEffect;
        Growthtime = growthtime;
    }
}

