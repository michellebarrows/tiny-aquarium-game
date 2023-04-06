using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolsMenu : MonoBehaviour
{
    [Header ("Menu Item Spacing")]
    public Vector2 spacing;

    Button mainButton;
    ToolsMenuItem[] menuItems;
    bool isExpanded = false;
    ToolsMenuItem activeButton;

    Vector2 mainButtonPosition;
    int numMenuItems;

    void Start()
    {
        numMenuItems = transform.childCount - 1;
        menuItems = new ToolsMenuItem[numMenuItems];
        activeButton = null;

        for(int i = 0; i < numMenuItems; i++) {
            menuItems[i] = transform.GetChild(i+1).GetComponent<ToolsMenuItem>();
        }

        mainButton = transform.GetChild(0).GetComponent<Button>();
        mainButton.onClick.AddListener(ToggleMenu);
        mainButton.transform.SetAsLastSibling();

        mainButtonPosition = mainButton.transform.position;

        //Reset menu items' positions to main button position to hide them
        ResetPositions();
    }

    void ResetPositions() {
        for(int i = 0; i < numMenuItems; i++) {
            menuItems[i].transformComponent.position = mainButtonPosition;
        }
    }

    void ToggleMenu() {
        isExpanded = !isExpanded;

        //if menu open
        if(isExpanded) {
            for(int i = 0; i < numMenuItems; i++) {
                menuItems[i].transformComponent.position = mainButtonPosition + spacing * (i + 1);
            }
        }
        //if menu closed
        else {
            for(int i = 0; i < numMenuItems; i++) {
                menuItems[i].transformComponent.position = mainButtonPosition;
                menuItems[i].SetActive(false);
                menuItems[i].SetToDefaultSprite();
            }
        }
    }

    void OnDestroy() {
        mainButton.onClick.RemoveListener(ToggleMenu);
    }

    //disable other tools when a tool is selected
    public void ActiveButtonSet(ToolsMenuItem active) {
        activeButton = active;
        foreach (ToolsMenuItem item in menuItems) {
            if(item != activeButton) {
                item.SetActive(false);
                item.SetToDefaultSprite();
            }
        }
    }

}
