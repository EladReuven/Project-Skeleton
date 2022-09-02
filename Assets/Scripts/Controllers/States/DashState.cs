using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers.States
{
    public class DashState : PlayerState
    {
        public Vector2 direction;
        public float dashTime;
        public float elapsedTime = 0;
        public override void Update()
        {
            if (elapsedTime >= dashTime)
            {
                controller.SetState(new IdleState("idle"));
            }
            else
            {
                elapsedTime += Time.deltaTime;
            }
        }

        public DashState(string tag, Vector2 direction, float dashTime) : base(tag)
        {
            this.direction = direction.normalized;
            this.dashTime = dashTime;
        }
    }
}
