using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowClick : MonoBehaviour
{
    public bool growSelected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown() {
        if(growSelected) {
            growSelected = false;
            Debug.Log("111222");
        } else {
            growSelected = true;
        }
    }
}
