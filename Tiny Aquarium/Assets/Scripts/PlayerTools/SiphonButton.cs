using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SiphonButton : MonoBehaviour
{
    public Sprite cancelSprite;
    public Sprite defaultSprite;

    public GameObject water;

    bool isActive;

    void Start() {
        isActive = false;
    }

    void Update() {
        //lower water on click if button is active
        if(isActive && Input.GetMouseButtonDown(0)) {
            //lower water
        }
    }

    //called on siphon button click
    public void SiphonActive() {
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
