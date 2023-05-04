using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishHunger : MonoBehaviour
{
    public GameObject foodObject;
    public float hungerTime = 90f;

    void Start() {

    }

    void Update() {

    }

    IEnumerator HungerRoutine() {
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
