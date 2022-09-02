using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers.States
{
    public class IdleState : PlayerState
    {
        public IdleState(string tag) : base(tag)
        {
        }

        public override void Update()
        {
            if (Input.GetButtonDown(controller.INPUT_FIRE_1))
            {
                controller.SetState(new AttackHoldState("holdAttack"));
                return;
            }

            var movement = new Vector2(Input.GetAxis(controller.VERTICAL_AXIS), Input.GetAxis(controller.HORIZONTAL_AXIS));
            if (movement.magnitude > 0)
            {
                controller.SetState(new MoveState("move",movement));
                return;
            }
        }
    }
}
