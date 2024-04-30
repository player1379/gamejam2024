using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// »¬¶¯Ìõ
/// <summary>
public class GrindSlider : MonoBehaviour
{
    public float speed = 2f;

    public bool trigger;
    private GameObject triggerObj;

    private void Start()
    {
        transform.localPosition = new Vector3(-7f, 0, 0);
    }

    private void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x + speed * Time.deltaTime, 0, 0);
        if (transform.localPosition.x > 7f)
        {
            Destroy(triggerObj);
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Space) && trigger == true)
        {
            Destroy(triggerObj);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        trigger = true;
        triggerObj = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        trigger = false;
        triggerObj = null;
    }
}

