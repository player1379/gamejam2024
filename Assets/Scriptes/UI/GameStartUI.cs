using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/// <summary>
/// 游戏开始场景UI
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
        // 只在编辑器中运行的退出代码
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}

