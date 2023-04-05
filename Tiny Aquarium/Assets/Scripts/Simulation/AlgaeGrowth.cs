using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlgaeGrowth : MonoBehaviour
{
    public List<Image> algaeSpots;
    public float growthTime;
    
    void Start()
    {
        //restore algae states from save 
        foreach (Image image in algaeSpots) {
            StartCoroutine(AlgaeGrowthRoutine(image));
        }
    }

    IEnumerator AlgaeGrowthRoutine(Image image) {
        float elapsedTime = 0.0f;
        Color c = image.color;

        while(elapsedTime < growthTime) {
            yield return null;
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Clamp01(elapsedTime / growthTime);
            image.color = c;
        }
    }
}
