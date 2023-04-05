using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FishAIState
{
    protected FishAI fishAI;
    public float timer = 0f;

    public FishAIState(FishAI newAI) {
        fishAI = newAI;
    }

    public void BeginStateBase() {
        timer = 0f;
        BeginState();
    }

    public void UpdateStateBase() {
        timer += Time.fixedDeltaTime;
        UpdateState();
    }

    //behavior when transitioning to state
    public abstract void BeginState();
    //behavior during state
    public abstract void UpdateState();
}
