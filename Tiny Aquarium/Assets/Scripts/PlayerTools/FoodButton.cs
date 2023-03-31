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
        if(isActive && Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Input.mousePosition;
            Instantiate(foodObject, mousePos, foodObject.transform.rotation);
        }
    }

    //called on food button click
    public void FoodActive() {
        isActive = !isActive;

        if(isActive) {
            //change sprite to cancel sprite
            GetComponent<Image>().sprite = cancelSprite;
            //spawn fish food on click
        }

        else {
            //change sprite to default sprite
            GetComponent<Image>().sprite = defaultSprite;
            //stop spawning food
        }
    }
}