using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{
    bool isPlanted = false;
    public SpriteRenderer plant;
    BoxCollider2D plantCollider;
    // public Sprite[] plantStages;

    // float timeBtwStages = 1f;
    // float timer;  
    // int plantIndex= 0;
    // Start is called before the first frame update
    void Start()
    {
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        plantCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(isPlanted) {
        //     timer -= Time.deltaTime;
        //     if(timer < 0 && plantIndex < plantStages.Length -1) {
        //         timer = timeBtwStages;
        //         plantIndex ++;
        //         UpdatePlant();
                
        //     }
        // }
    }

    private void OnMouseDown() {
        if(isPlanted) {
            Harvest();
        }
        else {
            Plant();
        }
    }

    void Harvest() {
        Debug.Log("harvest");
        plant.gameObject.SetActive(false);
        // plantIndex = 0;
        isPlanted = false;
    }

    void Plant() {
        // 如果有幼苗阶段增加stage相关内容
        // plantIndex ++;
        UpdatePlant();
        // timer = timeBtwStages;
        plant.gameObject.SetActive(true);
        isPlanted = true;
    }

    void UpdatePlant() {
        // plant.sprite = plantStages[plantIndex];
        plantCollider.size = plant.sprite.bounds.size;
        plantCollider.offset = new Vector2(0, plant.bounds.size.y/2);
    }
}
