using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


/// <summary>
/// 
/// <summary>
public class BeatScroller : MonoBehaviour
{
    public float spawnInterval;
    private float spawnTimer;
    public bool startPlaying;

    public int index;
    public GameObject arrow;
    public Sprite[] arrowSprites;
    public Transform[] arrowTransforms;
    private KeyCode[] keyCodes = new KeyCode[] { KeyCode.A, KeyCode.S, KeyCode.W, KeyCode.D };

    private ObjectPool<GameObject> arrowPool;

    public bool hasStart = false;

    private void Awake()
    {
        arrowPool = new ObjectPool<GameObject>(createArrow, actionOnGet, actionOnRelease, actionOnDestroy, true, 10, 100);
    }

    private void Start()
    {
        spawnInterval = 0.4f;
    }

    private void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;               
            }
        }
       
        if (startPlaying) 
        {
            spawnTimer += Time.deltaTime;
        }
        if (spawnTimer >= spawnInterval && startPlaying)
        {
            spawnTimer -= spawnInterval;
            index = Random.Range(0, 4);
            Spawn(index);
        }
    }

    GameObject createArrow()
    {
        var obj = Instantiate(arrow);
        obj.GetComponent<NoteOB>().pool = arrowPool;
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

    private void Spawn(int index)
    {
        GameObject temp = arrowPool.Get();
        temp.transform.SetParent(transform);
        temp.transform.position = arrowTransforms[index].position;
        temp.GetComponent<SpriteRenderer>().sprite = arrowSprites[index];
        temp.GetComponent<NoteOB>().keyTopress = keyCodes[index];
    }
}

