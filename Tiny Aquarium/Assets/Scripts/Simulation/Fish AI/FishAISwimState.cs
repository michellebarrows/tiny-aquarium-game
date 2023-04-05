using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAISwimState : FishAIState
{
    Vector3 swimVector; 
    float waitTime;

    public FishAISwimState(FishAI fishAI) : base(fishAI) {}

    public override void BeginState() {
        //get initial random position
        RandomPosition();
        waitTime = Random.Range(1, 10);
    }

    public override void UpdateState() {
        //change random position every few seconds
        if(timer > waitTime) {
            timer = 0f;
            waitTime = Random.Range(10, 20);
            RandomPosition();
        }

        //go to position
        fishAI.Swim(swimVector);

        //if food is found, go to eat state
        if(fishAI.FindFood() != null) {
            fishAI.ChangeState(fishAI.eatState);
        }
        //else randomly go idle
        float randomNumber = Random.Range(1, 100);
        if(randomNumber >= 3) {
            fishAI.ChangeState(fishAI.idleState);
        }   
    }

    public void RandomPosition() {
        swimVector = (new Vector3(Random.Range(-7f, 7f), Random.Range(-.5f, .5f), 0));
    }
}
