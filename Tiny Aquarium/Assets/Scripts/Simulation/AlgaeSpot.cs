using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlgaeSpot : MonoBehaviour
{
    public GameObject spongeButton;
    public Button AlgaeOnClick; 

    void Start() {
        AlgaeOnClick.onClick.AddListener(AlgaeOnClick_onClick);
    }

    public void ResetTransparency() {
        Image image = GetComponent<Image>();
        Color c = image.color;
        c.a = 0f;
        image.color = c; 
    }

    void AlgaeOnClick_onClick() {
        if(spongeButton.GetComponent<SpongeButton>().IsActive()) {
            ResetTransparency();
        }
    }
}
