using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Systems.Creatures
{
    [CustomEditor(typeof(LineOfSight))]
    public class FovEditor : Editor
    {
        private void OnSceneGUI()
        {
            // Circle Fow
            LineOfSight fow = (LineOfSight)target;
            Handles.color = Color.white;
            Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.SightRedius);
            // Circle AttackRng
            Handles.color = Color.red;
            Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.attackRange);

            // Create Angle Points On Radius
            Vector3 viewAngleA = fow.DirectionFromAngle(-fow.viewAngle / 2, false);
            Vector3 viewAngleB = fow.DirectionFromAngle(fow.viewAngle / 2, false);

            Handles.color = Color.white;
            Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.SightRedius);
            Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.SightRedius);

            Handles.color = Color.red;
            foreach (Transform visableTarget in fow.targetsAquired)
            {
                Handles.DrawLine(fow.transform.position, visableTarget.position);
            }

            Handles.color = Color.black;
            foreach (Transform targetsInRange in fow.targetInAttRange)
            {
                Handles.DrawLine(fow.transform.position, targetsInRange.position);
            }
        }
    }
}
