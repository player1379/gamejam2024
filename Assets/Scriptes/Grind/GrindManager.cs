using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// <summary>
public class GrindManager : MonoBehaviour
{
    public AudioSource myMusic;

    public BeatScroller BS;

    public static GrindManager instance;

    private void Start()
    {
        instance = this;
    }

    public void GrindStart()
    {
        BS.hasStart = true;
        AudioManager.Instance.Pause();
        myMusic.Play();
        StartCoroutine(GrindOverIE());
    }

    IEnumerator GrindOverIE()
    {
        yield return new WaitForSeconds(20);
        GrindOver();
    }

    public void GrindOver()
    {
        BS.hasStart = false;
        myMusic.Pause();
        Grind.Instance.Show();
        Chest.Instance.Show();
    }
}

