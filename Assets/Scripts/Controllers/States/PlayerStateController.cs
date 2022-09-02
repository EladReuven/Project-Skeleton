using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Controllers.States
{
    public class PlayerStateController : MonoBehaviour
    {
        public readonly string INPUT_FIRE_1 = "Fire1";
        public readonly string INPUT_FIRE_2 = "Fire2";
        public readonly string INPUT_FIRE_3 = "Fire3";
        public readonly string INPUT_DASH = "Dash";
        public readonly string VERTICAL_AXIS = "Vertical";
        public readonly string HORIZONTAL_AXIS = "Horizontal";

        public static PlayerStateController instance;

        public UnityEvent<PlayerState> OnStateChange;
        public string currentStae;

        public PlayerState state { get; private set; }

        private void Awake()
        {
            if (instance != null) return;

            instance = this;
            SetState(new IdleState("idle"));
        }


        private void Update()
        {
            state.Update();
        }

        public void SetState(PlayerState state)
        {
            this.state = state;
            currentStae = state.tag;
            OnStateChange.Invoke(state);
        }




    }

}

