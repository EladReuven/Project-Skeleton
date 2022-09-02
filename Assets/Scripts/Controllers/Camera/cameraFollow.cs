using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers.CameraCtrl
{
    public class cameraFollow : MonoBehaviour
    {
        [SerializeField] GameObject target;
        [SerializeField] float zfollowSpeed;
        [SerializeField] float xfollowSpeed;
        [SerializeField] float zOffset;
        [SerializeField] float xOffset;
        Vector3 cameraPosition;
        float x;
        float z;

        private void Start()
        {
            cameraPosition = Camera.main.transform.position;
            x = cameraPosition.x;//x is camera x axis coordinate
            z = cameraPosition.z;//z is camera z axis coordinate
        }

        void FixedUpdate()
        {
            //version 1 doesnt use Start Event
            //cameraPosition = Camera.main.transform.position;
            //x = (target.transform.position.x - cameraPosition.x + xOffset) * 0.01f * xfollowSpeed; // 1%*followSpeed closer towards our target(player) x axis
            //z = (target.transform.position.z - cameraPosition.z - zOffset) * 0.01f * zfollowSpeed; // 1%*followSpeed closer towards our target(player) z axis
            //Vector3 cameraMoveVector = new Vector3(x, 0, z);//vector that points on the Target(player)
            //Camera.main.transform.position = (cameraPosition + cameraMoveVector)* Time.timeScale;//   current camera position + the distance and angle we want to move to(cameraMoveVector) -->* timescale incase we want to pause the game(default equals 1)

            //uses Start Event
            x += (target.transform.position.x - x + xOffset) * 0.01f * xfollowSpeed;//moves 1%*followSpeed closer towards our target(player) x axis
            z += (target.transform.position.z - z - zOffset) * 0.01f * zfollowSpeed;//moves 1%*followSpeed closer towards our target(player) z axis
            cameraPosition = new Vector3(x, cameraPosition.y, z);
            Camera.main.transform.position = cameraPosition * Time.timeScale;//incase we want to pause the game(default equals 1)
        }
    }
}