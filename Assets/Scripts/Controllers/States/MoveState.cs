using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers.States
{
    public class MoveState : PlayerState
    {
        public Vector2 movement;

        public MoveState(string tag, Vector2 movement) : base(tag)
        {
            this.movement = movement;
        }

        public override void Update()
        {

            if (Input.GetButtonDown(controller.INPUT_FIRE_1))
            {
                controller.SetState(new AttackHoldState("holdAttack"));
                return;
            }

            movement = new Vector2(Input.GetAxis(controller.VERTICAL_AXIS), Input.GetAxis(controller.HORIZONTAL_AXIS));
            if (movement.magnitude > 0)
            {
                if (Input.GetButton(controller.INPUT_DASH))
                {
                    //TODO dynamicly set the dash time 
                    controller.SetState(new DashState("dash", movement, .5f));
                    return;
                }
                controller.SetState(this);
            }
            else
            {
                controller.SetState(new IdleState("idle"));
            }

        }
    }
}
