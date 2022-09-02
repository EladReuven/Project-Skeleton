using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers.States
{
    [System.Serializable]
    public abstract class PlayerState
    {
        protected PlayerStateController controller = PlayerStateController.instance;
        public string tag;
        public abstract void Update();

        public PlayerState(string tag)
        {
            this.tag = tag;
        }
    }

}
