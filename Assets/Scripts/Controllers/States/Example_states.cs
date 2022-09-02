using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controllers.States;

public class Example_states : MonoBehaviour
{
    //Create a method to be called by the event
    public void TestMovement(PlayerState state)
    {
        //Check if the event is of the type you want
        if (state.tag != "move") return;

        //Cast
        MoveState moveState = state as MoveState;
        //do what you want with the state
        Debug.Log($"Move to  { moveState.movement.x},{moveState.movement.y}");
    }



    //Another example 
    //Create a counter for combos
    int combos = 0;
    //create a method to be called by the event
    public void TestAttack(PlayerState state)
    {
        //This time we want to long two possible states
        //If the player is holding the attack we want to log for how long did it held 
        //When the player relese we want to do dammage, with the 3rd attack to do double the damage.
        //If the player attacked 3 time, we reset the combo

        //first, is the player holding the attack btn?
        if(state.tag != "holdAttack")
        {
            //is the player released the attack?
            if (state.tag != "releaseAttack") return;

            //Player release the attack
            var _releaseState = state as AttackReleaseState;
            var holdTime = _releaseState.holdTime % 60;
            holdTime = Mathf.FloorToInt(holdTime) + 1;
            combos++;
            if(combos == 3)
            {
                combos = 0;
                //get the hold time in seconds
                Debug.Log($"CRITICAL attack for { holdTime * 2}");
                return;
            }
            Debug.Log("attacked for " + holdTime);
            return;
        }
        //Player is holding the attack
        Debug.Log("Holding");
    }
}
 