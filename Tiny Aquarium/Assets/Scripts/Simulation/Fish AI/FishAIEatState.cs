using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAIEatState : FishAIState
{
    public FishAIEatState(FishAI fishAI) : base(fishAI) {}

    public override void BeginState() {

    }

    public override void UpdateState() {
        //find food
        GameObject foodTarget = fishAI.FindFood();
        //if food found, go eat it
        if(foodTarget != null) {
            fishAI.SwimToward(foodTarget);
        }
        //else if no food is found, go to idle state
        else {
            fishAI.ChangeState(fishAI.swimState);
        }
    }
}
