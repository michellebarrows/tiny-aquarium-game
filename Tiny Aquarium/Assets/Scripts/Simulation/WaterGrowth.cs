using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterGrowth : MonoBehaviour
{
    public float growthTime = 2000f;

    void Start()
    {
        //restore water state from save
        Image image = GetComponent<Image>();
        StartCoroutine(WaterGrowthRoutine(image));
    }

    IEnumerator WaterGrowthRoutine(Image image) {
        float elapsedTime = 10.0f;
        Color c = image.color;

        while(elapsedTime < growthTime) {
            yield return null;
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Clamp01(elapsedTime / growthTime);
            image.color = c;
        }
    }
}
