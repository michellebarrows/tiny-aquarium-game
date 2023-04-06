using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditMenuItem : MonoBehaviour
{
    public CanvasGroup editMenu;
    public GameObject tooltip;
    public GameObject itemToSpawn;
    public bool canSpawnMultiple;
    bool spawningActive;

    void Start() {
        spawningActive = false;
    }

    void Update() {
        //spawn designated object on click while active
        if(spawningActive && Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Input.mousePosition;
            Vector3 spawnPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
            if(ClickIsValid(spawnPos)) {
                Instantiate(itemToSpawn, spawnPos, Quaternion.identity);
                //deactivate spawns if only one item is allowed
                if(!canSpawnMultiple) {
                    spawningActive = false;
                }
            }
        }
    }

    //called when an item is clicked (duh lol)
    public void ItemClicked() {
        //hide menu without disabling this component
        editMenu.alpha = 0;
        editMenu.interactable = false;
        editMenu.blocksRaycasts = false;
        
        spawningActive = true;
        tooltip.SetActive(true);
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

    public void CancelItem() {
        spawningActive = false;
        tooltip.SetActive(false);
    }
}
