using UnityEngine;
using System.Collections;

/// <summary>
/// 物品基类
/// </summary>
public class Item 
{

    public int ID { get; set; }
    public string Name { get; set; }
    public ItemType Type { get; set; }
    public string Description { get; set; }
    public int Capacity { get; set; }
    public int BuyPrice { get; set; }
    public int SellPrice { get; set; }
    public string Sprite { get; set; }


    public Item()
    {
        this.ID = -1;
    }

    public Item(int id, string name, ItemType type, string des, int capacity, int buyPrice, int sellPrice,string sprite)
    {
        ID = id;
        Name = name;
        Type = type;
        Description = des;
        Capacity = capacity;
        BuyPrice = buyPrice;
        SellPrice = sellPrice;
        Sprite = sprite;
    }


    /// <summary>
    /// 物品类型
    /// </summary>
    public enum ItemType
    {
        Seed,
        Plant,
        Formula,
        Material,
        Medicament
    }


    /// <summary> 
    /// 得到提示面板应该显示什么样的内容
    /// </summary>
    /// <returns></returns>
    public virtual string GetToolTipText()
    {
        string color = "";       
        string text = string.Format("<color={4}>{0}</color>\n<size=10><color=blue>购买价格：{1} \n出售价格：{2}</color></size>\n<color=yellow><size=10>{3}</size></color>", Name, BuyPrice, SellPrice, Description, color);
        return text;
    }
}
