using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    #region ����ģʽ
    private static DialogManager instance;
    public static DialogManager Instance
    {
        get
        {
            //�������ֻ��ִ��һ��
            if (instance == null)
            {
                //��̬��ʽ���ܵ�����ͨ���� GetComponentȥ����
                //ֻ����Find ͨ�������ҵ�
                instance = GameObject.Find("StoryPanel").GetComponent<DialogManager>();
            }
            return instance;
        }
    }
    #endregion

    /// <summary>
    /// �Ի��ı��ļ�
    /// </summary>
    public TextAsset dialogDataFile;

    /// <summary>
    /// ����ɫͼ��
    /// </summary>
    public Image spriteLeft;

    /// <summary>
    /// �Ҳ��ɫͼ��
    /// </summary>
    public Image spriteRight;

    /// <summary>
    /// ��ɫ�����ı�
    /// </summary>
    public Text nameText;

    /// <summary>
    /// �Ի������ı�
    /// </summary>
    public Text dialogText;

    /// <summary>
    /// ��һ���Ի���ť
    /// </summary>
    public Button nextBtn;

    /// <summary>
    /// ѡ�ťԤ����
    /// </summary>
    public GameObject optionBtn;

    /// <summary>
    /// ѡ�ť���ڵ�
    /// </summary>
    public Transform buttonGroup;

    /// <summary>
    /// ��ɫ�����б�
    /// </summary>
    public List<Sprite> NPCsprites = new List<Sprite>();

    public List<Sprite> emotesprites = new List<Sprite>();

    /// <summary>
    /// ���������л�
    /// </summary>
    public List<Sprite> bgSprites = new List<Sprite>();

    public GameObject Bg;

    /// <summary>
    /// ��ɫ���ֶ�ӦͼƬ���ֵ�
    /// </summary>
    Dictionary<string,Sprite> imageDic = new Dictionary<string,Sprite>();

    /// <summary>
    /// ��ɫ�����ӦͼƬ
    /// </summary>
    Dictionary<string,Sprite> emoteDic = new Dictionary<string,Sprite>();

    /// <summary>
    /// ��ǰ�Ի�������ֵ
    /// </summary>
    public int dialogIndex;

    /// <summary>
    /// ��������
    /// </summary>
    public CanvasGroup canvasGroup;

    public GameObject BG2;

    /// <summary>
    /// �Ի��ı������зָ�
    /// </summary>
    private string[] dialogRows;

    //private AudioSource audioSource;

    private void Awake()
    {
        imageDic["��ţè"] = NPCsprites[0];
        imageDic["������"] = NPCsprites[1];
        imageDic["����Ů��"] = NPCsprites[2];
        imageDic["��������"] = NPCsprites[3];
        imageDic["��Ӷ��"] = NPCsprites[4];
        imageDic["Լ��"] = NPCsprites[5];
        imageDic["�粼�����"] = NPCsprites[6];
        //imageDic[""] = NPCsprites[6];


        emoteDic["�ޱ���"] = emotesprites[0];
        emoteDic["����"] = emotesprites[1];
        emoteDic["����"] = emotesprites[2];
        emoteDic["����"] = emotesprites[3];
        emoteDic["����"] = emotesprites[4];
        emoteDic["����"] = emotesprites[5];
        emoteDic["ȦȦ��"] = emotesprites[6];
        emoteDic["��������"] = emotesprites[7];
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
    /// �������ֺͶԻ�����
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
            nameText.text = "СŮ��";
        }        
        dialogText.text = dialog;
    }

    /// <summary>
    /// ��������ͼƬ
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
    /// ���±���ͼƬ
    /// </summary>
    /// <param name="index"></param>
    public void UpdateBg(int index)
    { 
        Bg.GetComponent<Image>().sprite = bgSprites[index];
    }

    /// <summary>
    /// �����ļ�
    /// </summary>
    /// <param name="textAsset"></param>
    public void ReadText(TextAsset textAsset)
    {
        dialogRows = textAsset.text.Split('\n');        
    }

    /// <summary>
    /// ��ʾ��ɫ���ı�
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
                //�Ի�����
                canvasGroup.alpha = 0;
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
                AudioManager.Instance.Pause();
            }
        }
    }

    /// <summary>
    /// ��һ�ζԻ�
    /// </summary>
    public void OnClickNext()
    {
        ShowDialogRow();
    }

    /// <summary>
    /// ʵ�������а�ť
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
    /// ѡ����������а�ť
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
    /// ѡ���Ч��
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
