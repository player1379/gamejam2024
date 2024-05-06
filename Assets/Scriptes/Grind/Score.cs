using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


/// <summary>
/// 
/// <summary>
public class Score : MonoBehaviour
{
    public float time = 0.5f;

    private void Start()
    {
        StartCoroutine(DestorySelf());
    }

    IEnumerator DestorySelf()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}

