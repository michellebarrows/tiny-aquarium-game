using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpongeButton : MonoBehaviour
{
    ToolsMenuItem menuItem;

    void Start() {
        menuItem = GetComponent<ToolsMenuItem>();
    }

    //called on sponge button click
    public void SpongeActive() {
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
