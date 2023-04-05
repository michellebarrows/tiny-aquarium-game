using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAI : MonoBehaviour
{
    //fish components
    Rigidbody2D rigidBody;
    SpriteRenderer spriteRenderer;
    public float speed = 2f; 
    public GameObject targetFood;

    //state components
    FishAIState currentState;
    public FishAIIdleState idleState{get; private set;}
    public FishAISwimState swimState{get; private set;}
    public FishAIEatState eatState{get; private set;}

    public void ChangeState(FishAIState newState) {
        currentState = newState;
        currentState.BeginStateBase();
    }

    void Start()
    {
        //set components
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();

        //set states
        idleState = new FishAIIdleState(this);
        swimState = new FishAISwimState(this);
        eatState = new FishAIEatState(this);
        currentState = idleState;
    }

    void FixedUpdate()
    {
        currentState.UpdateStateBase();
    }

    public GameObject FindFood() {
        GameObject[] foodFound = GameObject.FindGameObjectsWithTag("Food");

        if(foodFound.Length > 0) {
            return foodFound[0];
        }
        else {
            return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "Food") {
            Destroy(collider.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        spriteRenderer.flipX = true;
    }

    public void Swim(Vector3 offset) {
        if(offset != Vector3.zero) {
            offset.Normalize();
            rigidBody.velocity = offset *= speed;

            if(offset.x > 0) {
                spriteRenderer.flipX = true;
            }
            else {
                spriteRenderer.flipX = false;
            }
        }
    }

    public void SwimToward(GameObject target) {
        Swim(target.transform.position - transform.position);
    }

    public void Stop() {
        rigidBody.velocity = Vector3.zero;
    }
}
