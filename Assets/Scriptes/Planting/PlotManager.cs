using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{
    bool isPlanted = false;
    SpriteRenderer plant;
    // SpriteRenderer growPannel;
    BoxCollider2D plantCollider;
    // public Sprite plantStage;
    
    // public Sprite[] plantStages;

    // float timeBtwStages = 1f;
    // float timer;  
    // int plantIndex= 0;
 
    void Start()
    {
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        plantCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    void Update()
    {
    }

    private void OnMouseDown() {
        // Vector3 worldPosition = transform.position;
        // Vector2 screenPosition = Main.camera.WorldToScreenPoint(worldPosition);

        if(isPlanted) {
            UpdatePannel();
            // Harvest();
        }
        else {
            Plant();
        }
    }

    void Harvest() {
        plant.gameObject.SetActive(false);
        isPlanted = false;
    }

    void Plant() {
        isPlanted = true;
        UpdatePlant();
        plant.gameObject.SetActive(true);
    }

    void UpdatePannel() {
        // growPannel.gameObject.SetActive(true);
    }
    void UpdatePlant() {
        // plant.sprite = plantStages[plantIndex];
        plantCollider.size = plant.sprite.bounds.size;
        plantCollider.offset = new Vector2(0,plant.size.y/2);
    }
}
