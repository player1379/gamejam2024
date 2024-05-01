using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;


/// <summary>
/// 
/// <summary>
public class BubblePool : MonoBehaviour
{
    public GameObject bubble;
    public GameObject[] elementBubbles;

    public Transform[] pointTransforms;

    public float spawnInterval;
    private float spawnTimer;
    public float spawnTimer2;

    public int indexer;

    private ObjectPool<GameObject> bubblePool;
    private ObjectPool<GameObject> elementBubblePool;

    private void Awake()
    {
        bubblePool = new ObjectPool<GameObject>(createBubble, actionOnGet, actionOnRelease, actionOnDestroy, true, 10, 100);

        elementBubblePool = new ObjectPool<GameObject>(createFuncElementBubble, actionOnGet, actionOnRelease, actionOnDestroy,true,10,100);
    }

    private void Start()
    {
        spawnInterval = 0.5f;
        indexer = 0;
    }


    private void Update()
    {
        spawnTimer += Time.deltaTime;
        spawnTimer2 += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer -= spawnInterval;
            Spawn();
        }
        if (spawnTimer2 >= 10 * spawnInterval)
        {
            spawnTimer2 -= 10 * spawnInterval;
            CreateElementBubble();
        }
    }

    GameObject createBubble()
    {
        var obj = Instantiate(bubble,transform);
        obj.GetComponent<Bubble>().pool = bubblePool;
        return obj;
    }

    GameObject createFuncElementBubble()
    {
        var obj = Instantiate(elementBubbles[Random.Range(0,4)], transform);
        obj.GetComponent<ElementBubble>().pool = elementBubblePool;
        return obj;
    }

    void actionOnGet(GameObject obj)
    {
        obj.gameObject.SetActive(true);
    }

    void actionOnRelease(GameObject obj)
    {
        obj?.gameObject.SetActive(false);
    }

    void actionOnDestroy(GameObject obj) 
    {
        Destroy(obj);
    }


    void CreateElementBubble()
    {
        var obj = Instantiate(elementBubbles[Random.Range(0, 4)], transform);
        obj.transform.position = pointTransforms[Random.Range(0, pointTransforms.Length)].position;
    }


    private void Spawn()
    {
        GameObject temp = bubblePool.Get();
        temp.transform.position = pointTransforms[Random.Range(0, pointTransforms.Length)].position;
    }

    private void SpawnElement()
    {
        GameObject temp = elementBubblePool.Get();
        temp.transform.localPosition = pointTransforms[Random.Range(0, pointTransforms.Length)].position;
    }
}

