using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{
    bool isPlanted = false;
    public SpriteRenderer plant;
    
    public Sprite[] plantStages;

    float timeBtwStages = 1f;
    float timer;  
    int plantIndex= 0;

    void Start()
    {

    }

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
        if(plantIndex == plantStages.Length -1 ) {
            Harvest();
        }
        else {
            Plant();
        }
    }

    void Harvest() {
        plant.gameObject.SetActive(false);
        plantIndex = 0;
    }

    void Plant() {
        plantIndex ++;
        UpdatePlant();
        // timer = timeBtwStages;
        plant.gameObject.SetActive(true);
    }

    void UpdatePlant() {
        plant.sprite = plantStages[plantIndex];
    }
}
