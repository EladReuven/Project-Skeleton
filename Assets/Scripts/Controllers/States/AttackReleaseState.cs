using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers.States
{
    public class AttackReleaseState : PlayerState
    {
        public float holdTime = 0;
        public override void Update()
        {
            controller.SetState(new IdleState("idle"));
        }

        public AttackReleaseState(string tag, float holdTime) : base(tag)
        {
            this.holdTime = holdTime;
        }
    }
}
