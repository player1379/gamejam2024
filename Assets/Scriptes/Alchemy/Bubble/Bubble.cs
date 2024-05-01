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
    public BubbleAmount amount;

    public Animator animator;

    public float flySpeed;

    private void Start()
    {
        animator = GetComponent<Animator>();
        amount = GetComponentInParent<BubbleAmount>();
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
        amount.BubbleCount();
        //TODO 播放音效
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Bubble")
        {
            pool.Release(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

