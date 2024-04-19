using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using static Item;
using static Material;
using Unity.VisualScripting;



public class InventoryManager : MonoBehaviour
{

    #region 单例
    private static InventoryManager _instance;

    public static InventoryManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
            }
            return _instance;
        }
    }
    #endregion
    
    //物品信息的列表(集合)
    private List<Item> itemList;

    #region ToolTip
    private ToolTip toolTip;

    private bool isToolTipShow = false;

    private Vector2 toolTipPosionOffset = new Vector2(80, -80);
    #endregion

    //配方面板
    public GameObject formula;

    private Canvas canvas;

    #region PickedItem
    private bool isPickedItem = false;

    public bool IsPickedItem
    {
        get
        {
            return isPickedItem;
        }
    }

    private ItemUI pickedItem;//鼠标选中的物体

    public ItemUI PickedItem
    {
        get
        {
            return pickedItem;
        }
    }
    #endregion

    void Awake()
    {
        ParseItemJson();
    }

    void Start()
    {
        toolTip = GameObject.FindObjectOfType<ToolTip>();
        //formula = GameObject.Find("Formula").gameObject;
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        pickedItem = GameObject.Find("PickedItem").GetComponent<ItemUI>();
        pickedItem.Hide();
    }

    void Update()
    {
        if (isPickedItem)
        {
            //物品跟随鼠标
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, null, out position);
            pickedItem.SetLocalPosition(position);
        }else if (isToolTipShow)
        {
            //控制提示面板跟随鼠标
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, null, out position);
            toolTip.SetLocalPotion(position+toolTipPosionOffset);
        }
    }

    /// <summary>
    /// 解析物品信息
    /// </summary>
    void ParseItemJson()
    {
        itemList = new List<Item>();
        TextAsset itemText = Resources.Load<TextAsset>("Item");
        string itemsJson = itemText.text;//物品信息的Json格式
        JSONObject j = new JSONObject(itemsJson);
        foreach (JSONObject temp in j.List)
        {
            string typeStr = temp["type"].StringValue;
            ItemType itemType = (ItemType)System.Enum.Parse(typeof(ItemType), typeStr);

            int id = temp["id"].IntValue;
            string name = temp["name"].StringValue;
            string description = temp["description"].StringValue;
            int capacity = temp["capacity"].IntValue;
            int buyPrice = temp["buyPrice"].IntValue;
            int sellPrice = temp["sellPrice"].IntValue;
            string sprite = temp["sprite"].StringValue;

            Item item = null; 
            switch (itemType)
            {             
                case ItemType.Material:
                    string typeElement = temp["element"].StringValue;                   
                    string element = temp["element"].StringValue;
                    string sideEffect = temp["sideEffect"].StringValue;
                    item = new Material(id,name, ItemType.Material,description,capacity,buyPrice,sellPrice,sprite,element,sideEffect);
                    break;
                case ItemType.Medicament:
                    break;
                case ItemType.Formula:
                    string formula = temp["formula"].StringValue;
                    item = new Formulaes(id, name, ItemType.Formula, description, formula, sprite);
                    break;
            }
            itemList.Add(item);
        }
    }

    public Item GetItemById(int id)
    {
        foreach (Item item in itemList)
        {
            if (item.ID == id)
            {
                return item;
            }
        }
        return null;
    }

    public void ShowToolTip(string content)
    {
        if (this.isPickedItem) return;
        isToolTipShow = true;
        toolTip.Show(content);
    }

    public void HideToolTip()
    {
        isToolTipShow = false;
        toolTip.Hide();
    }

    //显示配方数据
    [HideInInspector]
    public string formulaesStr;

    //合成台数据
    [HideInInspector]
    public int[] alchemyInt;




    public void ShowFormula(Formulaes formulaes)
    {
        formula.gameObject.SetActive(true);
        formulaesStr = formulaes.Formula;
    }

    public void HideFormula()
    {
        formula.gameObject.SetActive(false);
    }

    //捡起物品槽指定数量的物品
    public void PickupItem(Item item,int amount)
    {
        PickedItem.SetItem(item, amount);
        isPickedItem = true;

        PickedItem.Show();
        this.toolTip.Hide();
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, null, out position);
        pickedItem.SetLocalPosition(position);
    }

    /// <summary>
    /// 从手上拿掉一个物品放在物品槽里面
    /// </summary>
    public void RemoveItem(int amount=1)
    {
        PickedItem.ReduceAmount(amount);
        if (PickedItem.Amount <= 0)
        {
            isPickedItem = false;
            PickedItem.Hide();
        }
    }

    //保存数据
    public void SaveInventory()
    {
        Chest.Instance.SaveInventory();

        PlayerPrefs.SetInt("CoinAmount", GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().CoinAmount);
    }

    public void LoadInventory()
    {
        Chest.Instance.LoadInventory();

        if (PlayerPrefs.HasKey("CoinAmount"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().CoinAmount = PlayerPrefs.GetInt("CoinAmount");
        }
    }

}