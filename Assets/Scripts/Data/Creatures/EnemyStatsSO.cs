using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Data.Creatures
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Create New Enemy SO", order = 1)]
    public class EnemyStatsSO : ScriptableObject
    {
        public int maxHealth;
        public int attackDamage;
        public float attackRange;
        public float visionRange;
        // ? not sure about the role but ok
        [Range(0, 360)]
        public float visionAngle;

    }
}

// script Created by Amit 