using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// <summary>
public class ButtonController : MonoBehaviour
{
    private SpriteRenderer SR;

    public Sprite defaltImage;
    public Sprite pressedImage;
    
    public KeyCode keyToPress;

    private void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            SR.sprite = pressedImage;
        }

        if (Input.GetKeyUp(keyToPress))
        {
            SR.sprite = defaltImage;
        }
    }
}

