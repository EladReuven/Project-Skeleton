using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers.States
{
    public class AttackHoldState : PlayerState
    {
        public float holdTime = 0;

        public AttackHoldState(string tag) : base(tag)
        {
        }

        public override void Update()
        {
            holdTime += Time.deltaTime;

            if ((Input.GetButtonUp(controller.INPUT_FIRE_1)))
            {
                if (controller.state.tag != "holdAttack") return;
                controller.SetState(new AttackReleaseState("releaseAttack", holdTime));
                return;
            }
        }
    }
}
