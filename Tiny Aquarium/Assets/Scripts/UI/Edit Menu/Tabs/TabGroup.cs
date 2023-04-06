using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    public List<SelectableTab> tabButtons;
    public SelectableTab selectedTab;
    public List<GameObject> pages;

    public void Subscribe(SelectableTab button) {
        if(tabButtons == null) {
            tabButtons = new List<SelectableTab>();
        }

        tabButtons.Add(button);
    }

    public void OnTabEnter(SelectableTab button) {

    }

    public void OnTabExit(SelectableTab button) {
        
    }

    public void OnTabSelected(SelectableTab button) {
        selectedTab = button;

        int index = button.transform.GetSiblingIndex();
        for(int i = 0; i < pages.Count; i++) {
            if (i == index) {
                pages[i].SetActive(true);
            }
            else {
                pages[i].SetActive(false);
            }
        }
    }

}
