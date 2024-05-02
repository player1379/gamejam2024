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
        int i = 0;
        foreach (var item in items)
        {
            if(item.Type == 0) {
                GameObject itemGameObject = Instantiate(plantItemPrefab, transform);
                itemGameObject.transform.localScale = Vector3.one;
                itemGameObject.transform.localPosition = new Vector2(-766 + i * 212, -63);
                itemGameObject.GetComponent<ItemUI>().SetItem(item);
                i++;
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
