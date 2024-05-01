using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Xml.Linq;
using TMPro;

public class ToolTip : MonoBehaviour 
{

    private Text toolTipText;
    private Text contentText;
    private CanvasGroup canvasGroup;

    private float targetAlpha = 0 ;

    public float smoothing = 1;

    public Sprite[] elements;
    public Text effectTxt;
    public GameObject[] gameObjects;

    void Start()
    {
        toolTipText = GetComponent<Text>();
        contentText = transform.Find("Content").GetComponent<Text>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if (canvasGroup.alpha != targetAlpha)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetAlpha,smoothing*Time.deltaTime);
            if (Mathf.Abs(canvasGroup.alpha - targetAlpha) < 0.01f)
            {
                canvasGroup.alpha = targetAlpha;
            }
        }
    }

    public void Show(string text)
    {
        toolTipText.text = text;
        contentText.text = text;
        targetAlpha = 1;
    }
    public void Hide()
    {
        targetAlpha = 0;
        foreach (GameObject obj in gameObjects)
        {
            Color c =new Color();
            c.a = 0;
            obj.GetComponent<Image>().color = c;
        }

    }
    public void SetLocalPotion(Vector3 position)
    {
        transform.localPosition = position;
    }

    public void ShowElement(string element)
    {
        if (element != "")
        {
            Color w = Color.white;
            for (int i = 0; i < element.Length; i++)
            {
                gameObjects[i].GetComponent<Image>().sprite = elements[(element[i] - 49)];
                gameObjects[i].GetComponent<Image>().color = w;
            }
        }
    }

    public void ShowEffect(string effect)
    {
        if (effect != "")
        {
            effectTxt.text = effect;
        }
    }
	
}
