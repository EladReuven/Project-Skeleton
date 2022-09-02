using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.Creatures
{
    public class LineOfSight : MonoBehaviour
    {
        public List<Transform> targetsAquired = new List<Transform>();
        public List<Transform> targetInAttRange = new List<Transform>();

        public float SightRedius { get; private set; }
        public float viewAngle { get; private set; }
        public float attackRange { get; private set; }


        [SerializeField] LayerMask targetMask;
        [SerializeField] LayerMask ObstacleMask;


        void FindVisableTargets()
        {
            targetsAquired.Clear();
            Collider[] targetInRadius = Physics.OverlapSphere(transform.position, SightRedius, targetMask);

            for (int i = 0; i < targetInRadius.Length; i++)
            {
                Transform target = targetInRadius[i].transform;
                Vector3 dirToTarger = (target.position - transform.position).normalized;
                if (Vector3.Angle(transform.forward, dirToTarger) < viewAngle / 2)
                {
                    float dstToTarget = Vector3.Distance(transform.position, target.position);

                    if (!Physics.Raycast(transform.position, dirToTarger, dstToTarget, ObstacleMask))
                    {
                        targetsAquired.Add(target);
                    }
                }
            }
        }

        internal void Init(float visionRange, float visionAngle, float attackRange)
        {
            this.viewAngle = visionAngle;
            this.attackRange = attackRange;
            this.SightRedius = visionRange;
        }

        void TargetsInAttackRange()
        {
            targetInAttRange.Clear();
            Collider[] targetsInRange = Physics.OverlapSphere(transform.position, attackRange, targetMask);

            for (int i = 0; i < targetsInRange.Length; i++)
            {
                Transform target = targetsInRange[i].transform;
                Vector3 dirToTarget = (target.position - transform.position).normalized;
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, ObstacleMask))
                {
                    targetInAttRange.Add(target);
                }
            }
        }

        IEnumerator findTargetsWithDelay(float delay)
        {
            while (true)
            {
                yield return new WaitForSeconds(delay);
                FindVisableTargets();
                TargetsInAttackRange();
            }
        }

        public Vector3 DirectionFromAngle(float viewAngle, bool angleIsGlobal)
        {
            if (!angleIsGlobal)
            {
                viewAngle += transform.eulerAngles.y;
            }
            return new Vector3(Mathf.Sin(viewAngle * Mathf.Deg2Rad), 0, Mathf.Cos(viewAngle * Mathf.Deg2Rad));
        }
    }
}
