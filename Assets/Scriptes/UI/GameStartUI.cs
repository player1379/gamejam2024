using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/// <summary>
/// ��Ϸ��ʼ����UI
/// <summary>
public class GameStartUI : MonoBehaviour
{
    public Button startBtn;
    public Button overBtn;
    public Button settingBtn;


    private void Start()
    {
        startBtn.onClick.AddListener(OnClickStartBtn);
        settingBtn.onClick.AddListener(OnClickSettingBtn);
        overBtn.onClick.AddListener(OnClickOverBtn);
    }


    void OnClickStartBtn()
    {
        SceneManager.LoadScene("GameScene");
    }

    void OnClickSettingBtn()
    {

    }

    void OnClickOverBtn()
    {
        // ֻ�ڱ༭�������е��˳�����
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}

