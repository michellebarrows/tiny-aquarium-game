using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodButton : MonoBehaviour
{
    public GameObject foodObject;
    ToolsMenuItem menuItem;

    void Start() {
        menuItem = GetComponent<ToolsMenuItem>();
    }

    void Update() {
        //spawn food on click if button is active
        if(menuItem.IsActive() && Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Input.mousePosition;
            Vector3 spawnPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
            if(ClickIsValid(spawnPos)) {
                Instantiate(foodObject, spawnPos, Quaternion.identity);
            }
        }
    }

    //called on food button click
    public void FoodActive() {
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

    bool ClickIsValid(Vector3 position) {
        //valid x coordinates
        if(position.x >= -7f && position.x <= 7f) {
            //valid y coordinates
            if(position.y >= -3f && position.y <= 3f) {
                return true;
            }
        }
        return false;
    }
}