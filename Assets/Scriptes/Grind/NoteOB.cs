using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


/// <summary>
/// 
/// <summary>
public class NoteOB : MonoBehaviour
{
    public bool canBePress;
    public bool canBeRelease;

    public float flySpeed;

    public ObjectPool<GameObject> pool;

    public KeyCode keyTopress;

    private void Start()
    {
        flySpeed = 2.0f;
        
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + flySpeed * Time.deltaTime);

        if (Input.GetKeyDown(keyTopress))
        {
            if (canBePress)
            {
                pool.Release(gameObject);
                canBePress = false;
                GrindManager.instance.NoteHit();
            }
        }
        if (canBeRelease)
        {
            pool.Release(gameObject);
            canBeRelease = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Activator")
        {
            canBePress = true;
        }
        else if (collision.tag == "Boundary")
        {
            canBeRelease = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Activator" && gameObject.activeSelf)
        {
            canBePress = false;
            GrindManager.instance.NoteMiss();
        }
    }
}

