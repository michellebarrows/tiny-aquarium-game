using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodButton : MonoBehaviour
{
    public GameObject foodObject;
    public Sprite cancelSprite;
    public Sprite defaultSprite;

    bool isActive;

    void Start() {
        isActive = false;
    }

    void Update() {
        //spawn food on click if button is active
        if(isActive && Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Input.mousePosition;
            Vector3 spawnPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
            Instantiate(foodObject, spawnPos, Quaternion.identity);
        }
    }

    //called on food button click
    public void FoodActive() {
        //swap active value
        isActive = !isActive;

        //swap sprite
        if(isActive) {
            GetComponent<Image>().sprite = cancelSprite;
        }
        else {
            GetComponent<Image>().sprite = defaultSprite;
        }
    }
}