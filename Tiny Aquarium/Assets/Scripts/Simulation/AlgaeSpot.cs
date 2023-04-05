using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlgaeSpot : MonoBehaviour
{
    public GameObject spongeButton;
    public Button AlgaeOnClick; 
    float elapsedTime = 0.0f;
    public float growthTime = 1800f;

    void Start() {
        AlgaeOnClick.onClick.AddListener(AlgaeOnClick_onClick);
        StartCoroutine(AlgaeGrowthRoutine(GetComponent<Image>()));
    }

    public void ResetTransparency() {
        Image image = GetComponent<Image>();
        Color c = image.color;
        c.a = 0f;
        image.color = c;
        elapsedTime = 0f; 
    }

    //called when sponge button is active and algae is clicked
    void AlgaeOnClick_onClick() {
        if(spongeButton.GetComponent<SpongeButton>().IsActive()) {
            ResetTransparency();
        }
    }

    //algae growth over growth time
    IEnumerator AlgaeGrowthRoutine(Image image) {
        Color c = image.color;

        while(true) {
            yield return null;
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Clamp01(elapsedTime / growthTime);
            if(c.a > 1f) {
                c.a = 1f;
            }
            image.color = c;
        }
    }
}
