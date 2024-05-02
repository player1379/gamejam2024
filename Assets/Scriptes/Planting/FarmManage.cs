using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmManage : MonoBehaviour
{
    public PlantItem selectPlant;
    public bool isPlanting = false;
    public GameObject plantItemPrefab;
    // public GameObject container;
    // Start is called before the first frame update
    void Start()
    {
        List<Item> items = InventoryManager.Instance.ItemList;
        foreach (var item in items)
        {
            if(item.Type == 0) {
            Debug.Log($"item + {item.Name}");
             GameObject itemGameObject = Instantiate(plantItemPrefab, transform);
            //  itemGameObject.GetComponent<ItemUI>().SetItem(item.Name);
            // 建prefab change sprites
            
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectPlant(PlantItem newPlant) {
        if(selectPlant == newPlant) {
            selectPlant = null;
            isPlanting = false;
            Debug.Log("111");
        
        } else {
            selectPlant = newPlant;
            isPlanting = true;
        }
    }
}
