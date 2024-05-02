using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;
using UnityEngine.UI;


/// <summary>
/// Ԫ������
/// <summary>
public class ElementBubble : Bubble
{
    public GameObject[] elementBubbles;

    public float fireBubbleExplosionRadius = 3f;

    public int indexer=5;

    public override void OnMouseDown()
    {
        if (gameObject == elementBubbles[0])//��Ԫ������
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, fireBubbleExplosionRadius);
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.tag == "Bubble")
                {
                    collider.GetComponent<Bubble>().animator.SetBool("play", true);
                }
            }
            animator.SetBool("play", true);
        }
        else if (gameObject == elementBubbles[1])//ˮԪ������
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 10f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.tag == "Bubble" && collider.gameObject.transform.position.y < gameObject.transform.position.y)
                {
                    collider.GetComponent<Bubble>().animator.SetBool("play", true);
                }
            }
            animator.SetBool("play", true);
        }
        else if (gameObject == elementBubbles[2])//��Ԫ������
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 10f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.tag == "Bubble" && collider.gameObject.transform.position.y > gameObject.transform.position.y)
                {
                    collider.GetComponent<Bubble>().animator.SetBool("play", true);
                }
            }
            animator.SetBool("play", true);
        }
        else if (gameObject == elementBubbles[3])//��Ԫ������
        {
            indexer--;
            if (indexer == 0)
            {
                animator.SetBool("play", true);
                indexer = 5;
            }
        }
    }


    private void OnDestroy()
    {
        Destroy(gameObject);
    }

}

