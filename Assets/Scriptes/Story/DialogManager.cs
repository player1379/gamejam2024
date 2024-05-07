using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    #region 单例模式
    private static DialogManager instance;
    public static DialogManager Instance
    {
        get
        {
            //下面代码只会执行一次
            if (instance == null)
            {
                //静态方式不能调用普通方法 GetComponent去查找
                //只能用Find 通过名字找到
                instance = GameObject.Find("StoryPanel").GetComponent<DialogManager>();
            }
            return instance;
        }
    }
    #endregion

    /// <summary>
    /// 对话文本文件
    /// </summary>
    public TextAsset dialogDataFile;

    /// <summary>
    /// 左侧角色图像
    /// </summary>
    public Image spriteLeft;

    /// <summary>
    /// 右侧角色图像
    /// </summary>
    public Image spriteRight;

    /// <summary>
    /// 角色名字文本
    /// </summary>
    public Text nameText;

    /// <summary>
    /// 对话内容文本
    /// </summary>
    public Text dialogText;

    /// <summary>
    /// 下一条对话按钮
    /// </summary>
    public Button nextBtn;

    /// <summary>
    /// 选项按钮预制体
    /// </summary>
    public GameObject optionBtn;

    /// <summary>
    /// 选项按钮父节点
    /// </summary>
    public Transform buttonGroup;

    /// <summary>
    /// 角色立绘列表
    /// </summary>
    public List<Sprite> NPCsprites = new List<Sprite>();

    public List<Sprite> emotesprites = new List<Sprite>();

    /// <summary>
    /// 背景立绘切换
    /// </summary>
    public List<Sprite> bgSprites = new List<Sprite>();

    public GameObject Bg;

    /// <summary>
    /// 角色名字对应图片的字典
    /// </summary>
    Dictionary<string,Sprite> imageDic = new Dictionary<string,Sprite>();

    /// <summary>
    /// 角色表情对应图片
    /// </summary>
    Dictionary<string,Sprite> emoteDic = new Dictionary<string,Sprite>();

    /// <summary>
    /// 当前对话的索引值
    /// </summary>
    public int dialogIndex;

    /// <summary>
    /// 剧情显隐
    /// </summary>
    public CanvasGroup canvasGroup;

    public GameObject BG2;

    /// <summary>
    /// 对话文本，按行分割
    /// </summary>
    private string[] dialogRows;

    //private AudioSource audioSource;

    private void Awake()
    {
        imageDic["奶牛猫"] = NPCsprites[0];
        imageDic["艾略特"] = NPCsprites[1];
        imageDic["人类女性"] = NPCsprites[2];
        imageDic["人类男性"] = NPCsprites[3];
        imageDic["雇佣兵"] = NPCsprites[4];
        imageDic["约翰"] = NPCsprites[5];
        imageDic["哥布林呱嗒"] = NPCsprites[6];
        //imageDic[""] = NPCsprites[6];


        emoteDic["无表情"] = emotesprites[0];
        emoteDic["悲伤"] = emotesprites[1];
        emoteDic["闭眼"] = emotesprites[2];
        emoteDic["生气"] = emotesprites[3];
        emoteDic["惊讶"] = emotesprites[4];
        emoteDic["开心"] = emotesprites[5];
        emoteDic["圈圈眼"] = emotesprites[6];
        emoteDic["黑线生气"] = emotesprites[7];
    }

    private void Start()
    {
        spriteLeft.GetComponent<CanvasGroup>().alpha = 1;
        spriteRight.GetComponent<CanvasGroup>().alpha = 0;
        ReadText(dialogDataFile);
        nextBtn.onClick.AddListener(OnClickNext);

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        dialogIndex = 101;
    }

    /// <summary>
    /// 更新名字和对话内容
    /// </summary>
    /// <param name="name"></param>
    /// <param name="dialog"></param>
    public void UpdateText(string name, string dialog)
    {
        if (name !="")
        {
            nameText.text = name;
        }
        else
        {
            nameText.text = "小女巫";
        }        
        dialogText.text = dialog;
    }

    /// <summary>
    /// 更新人物图片
    /// </summary>
    /// <param name="name"></param>
    /// <param name="atLeft"></param>
    public void UpdateImage(string emote, string name)
    {
        spriteLeft.sprite = emoteDic[emote];
        if (name != "") 
        {
            spriteRight.sprite = imageDic[name];
            spriteRight.GetComponent<CanvasGroup>().alpha = 1;
        }
        else
        {
            spriteRight.GetComponent<CanvasGroup>().alpha = 0;
        }
    }

    /// <summary>
    /// 更新背景图片
    /// </summary>
    /// <param name="index"></param>
    public void UpdateBg(int index)
    { 
        Bg.GetComponent<Image>().sprite = bgSprites[index];
    }

    /// <summary>
    /// 解析文件
    /// </summary>
    /// <param name="textAsset"></param>
    public void ReadText(TextAsset textAsset)
    {
        dialogRows = textAsset.text.Split('\n');        
    }

    /// <summary>
    /// 显示角色和文本
    /// </summary>
    public void ShowDialogRow()
    {        
        for (int i = 0; i < dialogRows.Length; i++)
        {
            if (dialogIndex < 100)
            {
                BG2.gameObject.SetActive(true);
            }
            else
            {
                BG2.gameObject.SetActive(false);
            }
            string[] cells = dialogRows[i].Split(',');
            if (cells[0] == "#" &&int.Parse(cells[1]) == dialogIndex)
            {
                UpdateText(cells[3], cells[4]);
                UpdateImage(cells[2], cells[3]);
                if (cells[7] != "")
                {
                    UpdateBg(int.Parse(cells[7]));
                }
                dialogIndex = int.Parse(cells[5]);
                nextBtn.gameObject.SetActive(true);
                break;
            }
            else if (cells[0] == "&" && int.Parse(cells[1]) == dialogIndex)
            {
                nextBtn.gameObject.SetActive(false);
                GenerateOption(i);
            }
            else if (cells[0] == "END" && int.Parse(cells[1]) == dialogIndex)
            {
                //对话结束
                canvasGroup.alpha = 0;
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
                AudioManager.Instance.Pause();
            }
        }
    }

    /// <summary>
    /// 下一段对话
    /// </summary>
    public void OnClickNext()
    {
        ShowDialogRow();
    }

    /// <summary>
    /// 实例化所有按钮
    /// </summary>
    /// <param name="index"></param>
    public void GenerateOption(int index)
    {
        string[] cells = dialogRows[index].Split(",");
        if (cells[0] == "&")
        {
            GameObject button = Instantiate(optionBtn, buttonGroup);
            button.GetComponentInChildren<Text>().text = cells[4];
            button.GetComponent<Button>().onClick.AddListener
                (
                    delegate 
                    { 
                        OnOptionClick(int.Parse(cells[5]));
                        if (cells[6] != "")
                        {
                            string[] effect = cells[6].Split('@');
                            OptionEffect(effect[0], int.Parse(effect[1]));
                        }
                        if (cells[7] != "")
                        {
                            //GameFacade.Instance.MainStoryIndex = int.Parse(cells[7]);
                        }
                    }
                );
            GenerateOption(index + 1);
        }
    }

    /// <summary>
    /// 选择后销毁所有按钮
    /// </summary>
    public void OnOptionClick(int id)
    {
        dialogIndex = id;
        ShowDialogRow();
        for (int i = 0; i < buttonGroup.childCount; i++)
        {
            Destroy(buttonGroup.GetChild(i).gameObject);
        }
    }

    /// <summary>
    /// 选择的效果
    /// </summary>
    /// <param name="effect"></param>
    /// <param name="parm"></param>
    /// <param name="target"></param>
    public void OptionEffect(string effect,int parm)
    {
        //switch (effect)
        //{
        //    case "food":
        //        GameFacade.Instance.Food += parm;
        //        break;
        //    case "money":
        //        GameFacade.Instance.Money += parm;
        //        break;
        //    case "worldLv":
        //        GameFacade.Instance.WordLv += parm;
        //        break;
        //    case "hero" :
        //        (GameFacade.Instance.Characters[parm] as Hero).IsUnlock = true;
        //        break;
        //    case "event":
        //        GameFacade.Instance.FightIndex = parm;
        //        GameFacade.Instance.IsFightIncident = true;
        //        break;
        //}
    }
}
