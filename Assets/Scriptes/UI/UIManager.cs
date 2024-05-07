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

    public Button SettingBtn;
    public Button SettingCloseBtn;
    public Button GameOverBtn;

    public Button NextDayBtn;

    public GameObject BubblePanelObj;
    public GameObject GrindPanelObj;
    public GameObject PlantPanelObj;
    public GameObject ExplorePanelObj;

    public GameObject SettingObj;

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

        NextDayBtn.onClick.AddListener(NextDayBtnDown);

        SettingBtn.onClick.AddListener(SettingBtnDown);
        SettingCloseBtn.onClick.AddListener(SetCloseBtn);
        GameOverBtn.onClick.AddListener(GameOver);
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
        AudioManager.Instance.PlayAlchemyBGM();
    }

    public void AlchemyHide()
    {
        Chest.Instance.Hide();
        FormulaPanel.Instance.Hide();
        BubblePanelObj.SetActive(false);
        ShowBtnUI();
        AudioManager.Instance.PlayHouseBGM();
    }

    void AlchemySwith()
    {
        Chest.Instance.Show();
        FormulaPanel.Instance.Hide();
        GrindPanelObj.SetActive(true);
        BubblePanelObj.SetActive(false);
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
        FormulaPanel.Instance.Show();
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
        AudioManager.Instance.PlayExploreBGM();
        ExplorePanelObj.SetActive(true);
    }

    public void ExplorePanelHide()
    { 
        ShowBtnUI();
        AudioManager.Instance.PlayHouseBGM();
        ExplorePanelObj.SetActive(false);
    }


    public void SettingBtnDown()
    {
        SettingObj.gameObject.SetActive(true);
    }

    public void SetCloseBtn()
    {
        SettingObj.gameObject.SetActive(false);
    }

    public void GameOver()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }


    public void NextDayBtnDown()
    {
        GameManager.Instance.Day++;
        GameManager.Instance.FTG = 10;
        if (GameManager.Instance.Day == 2)
        {
            DialogManager.Instance.dialogIndex = 30;
            DialogManager.Instance.ShowDialogRow();
            AudioManager.Instance.PlayMainStoryBGM();
            DialogManager.Instance.canvasGroup.alpha = 1;
            DialogManager.Instance.canvasGroup.interactable = true;
            DialogManager.Instance.canvasGroup.blocksRaycasts = true;
        }
        else if (GameManager.Instance.Day == 3)
        {
            DialogManager.Instance.dialogIndex = 60;
            DialogManager.Instance.ShowDialogRow();
            AudioManager.Instance.PlayMainStoryBGM();
            DialogManager.Instance.canvasGroup.alpha = 1;
            DialogManager.Instance.canvasGroup.interactable = true;
            DialogManager.Instance.canvasGroup.blocksRaycasts = true;
        }
        else if (GameManager.Instance.Day == 4)
        {
            DialogManager.Instance.dialogIndex = 80;
            DialogManager.Instance.ShowDialogRow();
            AudioManager.Instance.PlayMainStoryBGM();
            DialogManager.Instance.canvasGroup.alpha = 1;
            DialogManager.Instance.canvasGroup.interactable = true;
            DialogManager.Instance.canvasGroup.blocksRaycasts = true;
        }
    }
}

