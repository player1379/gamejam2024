using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// UI������
/// <summary>
public class UIManager : MonoBehaviour
{
    #region ����
    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("UIManager").GetComponent<UIManager>();
            }
            return _instance;
        }
    }
    #endregion

    public GameObject UIObj;
    public Button ChestBtn;
    public Button ChestCloseBtn;

    public Button AlchemyBtn;
    public Button AlchemyCloseBtn;
    public Button AlchemySwithBtn;

    public Button GrindBtn;
    public Button GrindCloseBtn;
    public Button GrindSwithBtn;

    public Button ExplorBtn;
    public Button ExplorCloseBtn;

    public Button PlantBtn;
    public Button PlantCloseBtn;

    public GameObject BubblePanelObj;
    public GameObject GrindPanelObj;
    public GameObject PlantPanelObj;
    public GameObject ExplorePanelObj;

    void Start()
    {
        ChestBtn.onClick.AddListener(Chest.Instance.Show);
        ChestCloseBtn.onClick.AddListener(Chest.Instance.Hide);

        AlchemyBtn.onClick.AddListener(AlchemyShow);
        AlchemyCloseBtn.onClick.AddListener(AlchemyHide);
        AlchemySwithBtn.onClick.AddListener(AlchemySwith);

        //GrindBtn
        GrindSwithBtn.onClick.AddListener(GrindPanelSwith);
        GrindCloseBtn.onClick.AddListener(GrindPanelHide);

        PlantBtn.onClick.AddListener(PlantPanelShow);
        PlantCloseBtn.onClick.AddListener(PlantPanelHide);

        ExplorBtn.onClick.AddListener(ExplorePanelShow);
        ExplorCloseBtn.onClick.AddListener(ExplorePanelHide);
    }


    public void HideBtnUI()
    {
        UIObj.SetActive(false);
    }

    public void ShowBtnUI()
    {
        UIObj.SetActive(true);
    }

    public void AlchemyShow()
    {
        Chest.Instance.Show();
        FormulaPanel.Instance.Show();
        BubblePanelObj.SetActive(true);
        HideBtnUI();
    }

    public void AlchemyHide()
    {
        Chest.Instance.Hide();
        FormulaPanel.Instance.Hide();
        BubblePanelObj.SetActive(false);
        ShowBtnUI();
    }

    void AlchemySwith()
    {
        Chest.Instance.Show();
        GrindPanelObj.SetActive(true);
        BubblePanelObj.SetActive(false);
    }

    void GrindPanelShow()
    {
        
    }

    public void GrindPanelHide() 
    {
        GrindPanelObj.SetActive(false);
        Chest.Instance.Hide();
        ShowBtnUI();
    }

    public void GrindPanelSwith()
    {
        Chest.Instance.Show();
        BubblePanelObj.SetActive(true);
        GrindPanelObj.SetActive(false);
    }

    public void PlantPanelShow()
    {
        HideBtnUI();
        Chest.Instance.SaveInventory();
        PlantPanelObj.SetActive(true);
        Chest.Instance.Hide();
        StartCoroutine(LoadChest());
    }

    IEnumerator LoadChest()
    {
        yield return new WaitForSeconds(0.1f);
        BackpackPanel.Instance.LoadChest();
    }

    public void PlantPanelHide() 
    {
        ShowBtnUI();
        PlantPanelObj.SetActive(false);
    }

    public void ExplorePanelShow()
    {
        HideBtnUI();
        ExplorePanelObj.SetActive(true);
    }

    public void ExplorePanelHide()
    { 
        ShowBtnUI();
        ExplorePanelObj.SetActive(false);
    }
}

