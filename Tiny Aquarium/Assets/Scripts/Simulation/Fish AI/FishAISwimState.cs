using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAISwimState : FishAIState
{
    Vector3 swimVector; 

    public FishAISwimState(FishAI fishAI) : base(fishAI) {}

    public override void BeginState() {
        //get initial random position
        RandomPosition();
    }

    public override void UpdateState() {
        //change random position every few seconds
        if(timer > 3f) {
            timer = 0f;
            RandomPosition();
        }

        //go to position
        fishAI.Swim(swimVector);

        //if food is found, go to eat state
        if(fishAI.FindFood() != null) {
            fishAI.ChangeState(fishAI.eatState);
        }
        //else randomly go idle
        float randomNumber = Random.Range(1, 10);
        if(randomNumber >= 3) {
            fishAI.ChangeState(fishAI.idleState);
        }   
    }

    public void RandomPosition() {
        swimVector = (new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0));
    }
}
