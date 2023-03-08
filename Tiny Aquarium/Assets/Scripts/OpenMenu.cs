using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public GameObject menu;

    public void OpenMenuOnClick() {
        if(menu != null) {
            bool isOpen = menu.activeSelf;
            menu.SetActive(!isOpen);
        }

    }
}
