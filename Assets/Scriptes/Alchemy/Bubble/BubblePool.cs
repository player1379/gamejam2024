using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;


/// <summary>
/// 气泡玩法
/// <summary>
public class BubblePool : MonoBehaviour
{
    public GameObject bubble;
    public GameObject[] elementBubbles;

    public Transform[] pointTransforms;
    public Transform ParentTransform;

    public float spawnInterval;
    private float spawnTimer;
    public float spawnTimer2;

    int index;
    int MaxIndex = 20;//可改成由配方决定数量

    public Slider Slider;

    private ObjectPool<GameObject> bubblePool;

    private void Awake()
    {
        bubblePool = new ObjectPool<GameObject>(createBubble, actionOnGet, actionOnRelease, actionOnDestroy, true, 10, 100);
    }

    private void Start()
    {
        spawnInterval = 0.5f;
        Slider.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.Instance.BubbleGameIsStart)
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

        Slider.value = (float)index / MaxIndex;
        if (MaxIndex < index)
        {
            //小游戏结束  显示炼金产物
            index = 0;
            GameManager.Instance.BubbleGameIsStart = false;
            CreateElementBubble();
            Chest.Instance.Show();
            Alchemy.Instance.Show();
            FormulaPanel.Instance.Show();
            Slider.gameObject.SetActive(false);
        }
    }

    #region 对象池
    GameObject createBubble()
    {
        var obj = Instantiate(bubble,transform);
        obj.GetComponent<Bubble>().pool = bubblePool;
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

    #endregion

    // 销毁所有气泡
    public void ClearBubble()
    {
        int childCount = ParentTransform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform child = ParentTransform.GetChild(i);
            Destroy(child.gameObject);
        }
    }

    void CreateElementBubble()
    {
        var obj = Instantiate(elementBubbles[Random.Range(0, 4)], transform);
        obj.transform.position = pointTransforms[Random.Range(0, pointTransforms.Length)].position;
        obj.transform.SetParent(ParentTransform);
    }

    private void Spawn()
    {
        GameObject temp = bubblePool.Get();
        temp.transform.position = pointTransforms[Random.Range(0, pointTransforms.Length)].position;
        temp.transform.SetParent(ParentTransform);
    }

    public void BubbleCount()
    {
        index++;
    }
}

