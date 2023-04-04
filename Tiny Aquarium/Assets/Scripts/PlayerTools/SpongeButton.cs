using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpongeButton : MonoBehaviour
{
    public Sprite cancelSprite;
    public Sprite defaultSprite;

    public bool isActive;

    void Start() {
        isActive = false;
    }

    void Update() {
        //erase algae on click if button is active
        if(isActive && Input.GetMouseButtonDown(0)) {
            //erase
        }
    }

    //called on sponge button click
    public void SpongeActive() {
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

    public bool IsActive() {
        return isActive;
    }
}
