using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolsMenu : MonoBehaviour
{
    [Header ("Menu Item Spacing")]
    [SerializeField] Vector2 spacing;

    Button mainButton;
    ToolsMenuItem[] menuItems;
    bool isExpanded = false;

    Vector2 mainButtonPosition;
    int numMenuItems;

    void Start()
    {
        numMenuItems = transform.childCount - 1;
        Debug.Log(numMenuItems);
        menuItems = new ToolsMenuItem[numMenuItems];

        for(int i = 0; i < numMenuItems; i++) {
            menuItems[i] = transform.GetChild(i+1).GetComponent<ToolsMenuItem>();
        }
        Debug.Log(menuItems);

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
            }
        }
    }

    void OnDestroy() {
        mainButton.onClick.RemoveListener(ToggleMenu);
    }

}
