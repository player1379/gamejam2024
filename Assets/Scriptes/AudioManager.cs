using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 音效管理
/// <summary>
public class AudioManager : MonoBehaviour
{
    #region 单例
    private static AudioManager _instance;

    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("AudioManager").GetComponent<AudioManager>();
            }
            return _instance;
        }
    }
    #endregion

    private AudioSource audioSource;

    public AudioClip[] audioClips;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Pause()
    {
        audioSource.Pause();
    }

    public void PlayHouseBGM()
    {
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }

    public void PlayExploreBGM()
    {
        audioSource.clip = audioClips[1];
        audioSource.Play();
    }

    public void PlayStoryBGM()
    {
        audioSource.clip = audioClips[2];
        audioSource.Play();
    }

    public void PlayAlchemyBGM()
    {
        audioSource.clip = audioClips[3];
        audioSource.Play();
    }

    public void PlayMainStoryBGM()
    {
        audioSource.clip = audioClips[4];
        audioSource.Play();
    }
}

