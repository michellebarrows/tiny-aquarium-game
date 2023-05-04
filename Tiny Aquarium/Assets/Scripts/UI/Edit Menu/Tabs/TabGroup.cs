using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<SelectableTab> tabButtons;
    public SelectableTab selectedTab;
    public List<GameObject> pages;
    public Sprite selectedSprite;
    public Sprite defaultSprite;

    public void Subscribe(SelectableTab button) {
        if(tabButtons == null) {
            tabButtons = new List<SelectableTab>();
        }

        tabButtons.Add(button);
    }

    public void OnTabEnter(SelectableTab button) {
        button.background.sprite = selectedSprite;
    }

    public void OnTabExit(SelectableTab button) {
        if(button != selectedTab) {
            button.background.sprite = defaultSprite;
        }
    }

    public void OnTabSelected(SelectableTab button) {
        ResetTabs();

        selectedTab = button;
        button.background.sprite = selectedSprite;
        
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

    public void ResetTabs() {
        foreach(SelectableTab button in tabButtons) {
            button.background.sprite = defaultSprite;
        }
    }

}
