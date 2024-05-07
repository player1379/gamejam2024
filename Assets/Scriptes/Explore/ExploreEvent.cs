using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// ð���¼�
/// <summary>
public class ExploreEvent : MonoBehaviour
{
    //����ID��
    public List<int> idLists;

    //����������
    public int[] storyIndex;

    //�䷽ID
    public int formulaID;

    //̽�մ���
    public int storyCount;

    private Button OnClickButton;

    private void Start()
    {
        OnClickButton = GetComponent<Button>();
        OnClickButton.onClick.AddListener(OnClickButtonDown);
    }

    public void OnClickButtonDown()
    {
        Debug.Log(gameObject.name);
        storyCount++;
        int id = Random.Range(0, idLists.Count);
        Chest.Instance.StoreItem(idLists[id]);
        switch (storyCount)
        {
            case 1:
                FormulaPanel.Instance.StoreItem(formulaID);
                DialogManager.Instance.dialogIndex = storyIndex[0];
                DialogManager.Instance.ShowDialogRow();
                AudioManager.Instance.PlayStoryBGM();
                DialogManager.Instance.canvasGroup.alpha = 1;
                DialogManager.Instance.canvasGroup.interactable = true;
                DialogManager.Instance.canvasGroup.blocksRaycasts = true;
                break;
            case 5:
                DialogManager.Instance.dialogIndex = storyIndex[1];
                DialogManager.Instance.ShowDialogRow();
                AudioManager.Instance.PlayStoryBGM();
                DialogManager.Instance.canvasGroup.alpha = 1;
                DialogManager.Instance.canvasGroup.interactable = true;
                DialogManager.Instance.canvasGroup.blocksRaycasts = true;
                break;
            case 10:
                DialogManager.Instance.dialogIndex = storyIndex[2];
                DialogManager.Instance.ShowDialogRow();
                AudioManager.Instance.PlayStoryBGM();
                DialogManager.Instance.canvasGroup.alpha = 1;
                DialogManager.Instance.canvasGroup.interactable = true;
                DialogManager.Instance.canvasGroup.blocksRaycasts = true;
                break;
        }
    }
}

