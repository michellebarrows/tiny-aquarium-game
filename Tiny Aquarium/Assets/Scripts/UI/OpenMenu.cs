using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public GameObject menu;

    public void OpenMenuOnClick() {
        if(menu != null) {
            menu.SetActive(!menu.activeSelf);
            bool isOpen = menu.activeSelf;
            
            //reset visibility
            if(isOpen) {
                menu.GetComponent<CanvasGroup>().alpha = 1;
                menu.GetComponent<CanvasGroup>().interactable = true;
                menu.GetComponent<CanvasGroup>().blocksRaycasts = true;
            }
        }

    }
}
