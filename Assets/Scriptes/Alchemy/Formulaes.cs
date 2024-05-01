using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ≈‰∑Ω¿‡
/// <summary>
public class Formulaes: Item
{
    public string Formula { get; set; }

    public int Product { get; set; }

    public Formulaes(int id, string name, ItemType type,string des,string formula,string sprite,int product)
    {
        ID = id;
        Name = name;
        Type = type;
        Description = des;
        Formula = formula;
        Sprite = sprite;
        Product = product;
    }
}

