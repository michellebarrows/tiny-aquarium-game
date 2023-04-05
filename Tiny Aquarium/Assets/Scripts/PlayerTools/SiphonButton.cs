using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SiphonButton : MonoBehaviour
{
    ToolsMenuItem menuItem;

    public GameObject water;

    void Start() {
        menuItem = GetComponent<ToolsMenuItem>();
    }

    void Update() {
        //lower water on click if button is active
        if(menuItem.IsActive() && Input.GetMouseButtonDown(0)) {
            //lower water
        }
    }

    //called on siphon button click
    public void SiphonActive() {
        //swap active value
        menuItem.SetActive(!menuItem.IsActive());
        //swap sprite
        if(menuItem.IsActive()) {
            menuItem.SetToActiveSprite();
        }
        else {
            menuItem.SetToDefaultSprite();
        } 
    }
}
