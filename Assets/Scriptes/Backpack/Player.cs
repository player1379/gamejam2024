using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private int coinAmount = 100;
    private Text coinText;
    public int CoinAmount
    {
        get
        {
            return coinAmount;
        }
        set
        {
            coinAmount = value;
            coinText.text = coinAmount.ToString();
        }
    }

    public GameObject ButtonObj;
    public Button ChestBtn;
    public Button ChestCloseBtn;
    public Button AlchemyBtn;
    public Button ExplorBtn;
    public Button ReadingBtn;
    public Button PlantBtn;

    void Start()
    {
        ChestBtn.onClick.AddListener(ChestShow);
        ChestCloseBtn.onClick.AddListener(ChestHide);
        AlchemyBtn.onClick.AddListener(AlchemyShow);
    }


	void Update () 
    {
        //G 随机得到一个物品放到背包里面
        if (Input.GetKeyDown(KeyCode.G))
        {
            Chest.Instance.StoreItem(1001);
            Chest.Instance.StoreItem(2001);
            Chest.Instance.StoreItem(2002);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            FormulaPanel.Instance.StoreItem(3001);
        }

        //T 控制背包的显示和隐藏
        if (Input.GetKeyDown(KeyCode.T))
        {
            Chest.Instance.DisplaySwitch();
        }
	}

    void ChestShow()
    {
        Chest.Instance.Show();
    }

    void ChestHide() 
    {
        Chest.Instance.Hide();
    }

    void AlchemyShow()
    {
        Chest.Instance.Show();
        Alchemy.Instance.Show();
        FormulaPanel.Instance.Show();
        InventoryManager.Instance.HideAllButton();
    }



    /// <summary>
    /// 消费
    /// </summary>
    public bool ConsumeCoin(int amount)
    {
        if (coinAmount >= amount)
        {
            coinAmount -= amount;
            coinText.text = coinAmount.ToString();
            return true;
        }
        return false;
    }

    /// <summary>
    /// 赚取金币
    /// </summary>
    /// <param name="amount"></param>
    public void EarnCoin(int amount)
    {
        this.coinAmount += amount;
        coinText.text = coinAmount.ToString();
    }
}
