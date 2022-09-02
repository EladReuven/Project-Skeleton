using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerLookTowards : MonoBehaviour
    {
        [SerializeField] Camera mainCamera;
        [SerializeField] GameObject playerModel;

        private void Update()
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            if(groundPlane.Raycast(ray, out rayLength))
            {
                Vector3 pointToLook = ray.GetPoint(rayLength);
                Debug.DrawLine(mainCamera.transform.position, pointToLook,Color.red);
                playerModel.transform.LookAt(new Vector3(pointToLook.x, playerModel.transform.position.y, pointToLook.z));
            }
        }
    }
}
