using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// UI¹ÜÀíÆ÷
/// <summary>
public class UIManager : MonoBehaviour
{
    #region µ¥Àý
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
    public GameObject StoryPanelObj;
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
        BubblePanelObj.SetActive(true);
        Alchemy.Instance.Show();
        FormulaPanel.Instance.Show();
        HideBtnUI();
    }

    public void AlchemyHide()
    {
        Debug.Log(2);
        Chest.Instance.Hide();
        BubblePanelObj.SetActive(false);
        Alchemy.Instance.Hide();
        FormulaPanel.Instance.Hide();
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

    void ExploreShow()
    {

    }


}

