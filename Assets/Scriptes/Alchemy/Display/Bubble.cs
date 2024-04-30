using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;


/// <summary>
/// 气泡类
/// <summary>
public class Bubble : MonoBehaviour
{
    public ObjectPool<GameObject> pool;

    public Animator animator;

    public float flySpeed;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("play", false);
    }

    public void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + flySpeed * Time.deltaTime);
    }


    public virtual void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("play", true);           
        }
    }

    private void DestroyGameObject()
    {
        pool.Release(gameObject);
        //TODO 播放音效
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pool.Release(gameObject);
    }
}

