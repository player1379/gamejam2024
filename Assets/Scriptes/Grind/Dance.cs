using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// <summary>
public class Dance : MonoBehaviour
{
    private SpriteRenderer Sprite;

    public Sprite[] sprites;

    private void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
       
        if (horizontalInput != 0)
        {
            Sprite.sprite = sprites[horizontalInput > 0 ? 1 : 0];
            //Debug.Log(horizontalInput > 0 ? Sprite.sprite = sprites[1] : Sprite.sprite = sprites[0];
        }
        if (verticalInput != 0)
        {
            Sprite.sprite = sprites[verticalInput > 0 ? 2 : 3];
            //Debug.Log(verticalInput > 0 ? Sprite.sprite = sprites[2] : Sprite.sprite = sprites[3]);
        }
    }
}

