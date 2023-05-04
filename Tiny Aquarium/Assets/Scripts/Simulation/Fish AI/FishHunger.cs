using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishHunger : MonoBehaviour
{
    float hungerScore;
    public GameObject indicator;

    void Start() {
        hungerScore = 0f;
    }

    void Update() {
        hungerScore += Time.deltaTime;

        if(hungerScore >= 60f) {
            indicator.SetActive(true);
        }
    }

    public void ResetHunger() {
        hungerScore = 0f;
        indicator.SetActive(false);
    }
}
