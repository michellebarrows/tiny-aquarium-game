using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAIIdleState : FishAIState
{
    public FishAIIdleState(FishAI fishAI) : base(fishAI) {}

    public override void BeginState() {
        
    }

    public override void UpdateState() {
        //do nothing

        //if food is found, go to eat state
        if(fishAI.FindFood() != null) {
            fishAI.ChangeState(fishAI.eatState);
        }
        //else start swimming after a few seconds
        if(timer > Random.Range(1, 10)) {
            timer = 0f;
            fishAI.ChangeState(fishAI.swimState);
        }
        
    }
}
