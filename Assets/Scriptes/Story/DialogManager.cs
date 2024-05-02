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
                instance = GameObject.Find("DialogManager").GetComponent<DialogManager>();
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
    public List<Sprite> sprites = new List<Sprite>();

    /// <summary>
    /// ��ɫ���ֶ�ӦͼƬ���ֵ�
    /// </summary>
    Dictionary<string,Sprite> imageDic = new Dictionary<string,Sprite>();

    /// <summary>
    /// ��ǰ�Ի�������ֵ
    /// </summary>
    public int dialogIndex;

    /// <summary>
    /// �Ի��ı������зָ�
    /// </summary>
    private string[] dialogRows;

    private AudioSource audioSource;

    private void Awake()
    {
        imageDic["����"] = sprites[0];
        imageDic["�԰�"] = sprites[1];
        imageDic["��ʹ"] = sprites[2];
        imageDic["����"] = sprites[3];
        imageDic["��ʿ"] = sprites[4];
        imageDic["�峤"] = sprites[5];
        imageDic["����"] = sprites[6];
        imageDic["��үү"] = sprites[7];
    }

    private void Start()
    {
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        //audioSource.volume = GameFacade.Instance.SoundValue;

        spriteLeft.GetComponent<CanvasGroup>().alpha = 0;
        spriteRight.GetComponent<CanvasGroup>().alpha = 0;
        ReadText(dialogDataFile);
        //dialogIndex = GameFacade.Instance.StoryIndex;
        ShowDialogRow();
    }

    /// <summary>
    /// �������ֺͶԻ�����
    /// </summary>
    /// <param name="name"></param>
    /// <param name="dialog"></param>
    public void UpdateText(string name, string dialog)
    {
        nameText.text = name; 
        dialogText.text = dialog;
    }

    /// <summary>
    /// ��������ͼƬ
    /// </summary>
    /// <param name="name"></param>
    /// <param name="atLeft"></param>
    public void UpdateImage(string name,string positin)
    {
        if (positin == "��")
        {
            spriteLeft.sprite = imageDic[name];
            spriteLeft.GetComponent<CanvasGroup>().alpha = 1;
            spriteRight.GetComponent<CanvasGroup>().alpha = 0;
        }
        else if (positin == "��") 
        {
            spriteRight.sprite = imageDic[name];
            spriteRight.GetComponent<CanvasGroup>().alpha = 1;
            spriteLeft.GetComponent<CanvasGroup>().alpha = 0;
        }
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
            string[] cells = dialogRows[i].Split(',');
            if (cells[0] == "#" &&int.Parse(cells[1]) == dialogIndex)
            {
                UpdateText(cells[2], cells[4]);
                UpdateImage(cells[2], cells[3]);

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
                //#��֧�߹���
                if (cells[2] == "#")
                {
                    //GameFacade.Instance.IncidentCount++;
                }
                //GameFacade.Instance.IsStoryOver = true;
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
