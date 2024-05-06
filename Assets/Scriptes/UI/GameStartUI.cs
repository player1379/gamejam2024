using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;


/// <summary>
/// 游戏开始场景UI
/// <summary>
public class GameStartUI : MonoBehaviour
{
    public Button startBtn;
    public Button overBtn;
    public Button settingBtn;

    public VideoPlayer PV;

    public CanvasGroup canvas;

    private AudioSource audioSource;

    private void Start()
    {
        startBtn.onClick.AddListener(OnClickStartBtn);
        settingBtn.onClick.AddListener(OnClickSettingBtn);
        overBtn.onClick.AddListener(OnClickOverBtn);

        audioSource = GetComponent<AudioSource>();
    }

    void OnClickStartBtn()
    {
        audioSource.Pause();
        StartCoroutine(LoadScene());
        canvas.alpha = 0;
        PV.Play();
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds((float)PV.clip.length);
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

