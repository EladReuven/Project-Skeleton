using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers.Items

{
    public class Weapon : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.gameObject.name);
            Debug.Log("trigger");
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log(collision.gameObject.name);
            Debug.Log("collision");

        }
    }
}