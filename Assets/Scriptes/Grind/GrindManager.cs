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
        myMusic.Play();
    }

    public void NoteHit()
    {
        Debug.Log("Hit");
    }

    public void NoteMiss()
    {
        Debug.Log("MISSSSSSSS");
    }

}

