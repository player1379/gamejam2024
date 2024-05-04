using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// ÷≤ŒÔ≈‡”˝∞¥≈•
/// <summary>
public class GorwthTip : MonoBehaviour
{
    public Text itemName;
    private CanvasGroup canvasGroup;

    public Button btn1;
    public Button btn2;

    public ItemUI itemUI;

    private float targetAlpha = 0;
    public float smoothing = 3;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        btn1.onClick.AddListener(OnButton1ClickDown);
        btn2.onClick.AddListener(OnButton2ClickDown);
    }

    void Update()
    {
        if (canvasGroup.alpha != targetAlpha)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetAlpha, smoothing * Time.deltaTime);
            if (Mathf.Abs(canvasGroup.alpha - targetAlpha) < 0.01f)
            {
                canvasGroup.alpha = targetAlpha;
            }
        }
    }

    public void Show(string text)
    {
        itemName.text = text;
        targetAlpha = 1;
    }

    public void Hide()
    {
        targetAlpha = 0;
    }

    public void SetLocalPotion(Vector3 position)
    {
        transform.localPosition = position;
    }

    public void OnButton1ClickDown()
    {
        Plant plant = itemUI.Item as Plant;
        int id = plant.ID;
        id += 1;
        if (plant.CanPlant)
        {
            itemUI.SetItem(InventoryManager.Instance.GetItemById(id));
            Hide();
        }
    }

    public void OnButton2ClickDown()
    {
        Plant plant = itemUI.Item as Plant;
        int id = plant.ID;
        id += Random.Range(2,4);
        if (plant.CanPlant)
        {
            itemUI.SetItem(InventoryManager.Instance.GetItemById(id));
            Hide();
        }
    }
}

