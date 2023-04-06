using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolsMenuItem : MonoBehaviour
{
    public ToolsMenu parentMenu;
    public Transform transformComponent;
    public bool isActive;
    public Sprite defaultSprite;
    public Sprite cancelSprite;

    void Awake()
    {
        transformComponent = transform;
        isActive = false;
    }

    public bool IsActive() {
        return isActive;
    }

    public void SetActive(bool state) {
        isActive = state;
        if(isActive) {
            parentMenu.ActiveButtonSet(this);
        }
    }

    public void SetToDefaultSprite() {
        GetComponent<Image>().sprite = defaultSprite;
    }

    public void SetToActiveSprite() {
        GetComponent<Image>().sprite = cancelSprite;
    }

}
