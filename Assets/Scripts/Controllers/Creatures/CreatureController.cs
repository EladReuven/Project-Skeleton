using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Data.Creatures;
using System.Events;
using Systems.Creatures;

namespace Controllers.Creatures
{
    public class CreatureController : MonoBehaviour
    {

        [SerializeField] EnemyStatsSO data;
        [SerializeField] CreatureEvents enemyEvent;
        [SerializeField] LineOfSight LineOfSight;

        private int currentHealth;
        private int currentDamage;


        private void Awake()
        {
            currentHealth = data.maxHealth;
            currentDamage = data.attackDamage;

            if (LineOfSight == null) return;
            LineOfSight.Init(data.visionRange, data.visionAngle, data.attackRange);

        }

  

        // Can be change if we decide the player manage all combat logic
        private void TakeDamage(int damageTaken)
        {
            if (currentHealth > 0)
            {
                currentHealth -= damageTaken;
                // Debug
                Debug.Log("Damage Taken");
            }
            else if (currentHealth <= 0)
            {
                currentHealth = 0;
                enemyEvent.enemyKilled.Invoke();
                Debug.Log("Enemy Killed");
            }
        }
    }

}

// Code By Amit
