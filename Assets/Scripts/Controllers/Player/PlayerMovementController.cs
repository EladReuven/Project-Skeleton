using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        const string HORIZONTAL_AXIS = "Horizontal";
        const string VERTICAL_AXIS = "Vertical";

        public DashData data; //data containing variables like max speed, acceleration, dash variables...

    
        [SerializeField] Rigidbody rb;
        Vector3 cameraRelativeMovement;
        Vector3 camForward;
        Vector3 camRight;
        bool dashAvailable = true;
        bool lockMovement = false;
        float animovementX;
        float animovementZ;

        private void Start()
        {
            //get camera normalized directional input
            Camera mainCamera = Camera.main;
            camForward = mainCamera.transform.forward;
            camRight = mainCamera.transform.right;
            camForward.y = 0;
            camRight.y = 0;
            camForward = camForward.normalized;
            camRight = camRight.normalized;
        }

        private void Update()
        {
            //get player input
            float horizontalInput = Input.GetAxisRaw(HORIZONTAL_AXIS);
            float verticalInput = Input.GetAxisRaw(VERTICAL_AXIS);

            //create direction-relative-input vectors
            Vector3 forwardRelativeVerticalInput = verticalInput * camForward;
            Vector3 rightRelativeHorizontalInput = horizontalInput * camRight;


            //movement relative to direction camera is facing
            cameraRelativeMovement = (forwardRelativeVerticalInput + rightRelativeHorizontalInput).normalized;
            animovementX = cameraRelativeMovement.x;
            animovementZ = cameraRelativeMovement.z;

            if (Input.GetKeyDown(data.dashKey) && dashAvailable)
            {
                Dash();
            }
            if (!lockMovement)
            {
                Move();
            }
        }

        private void Dash()
        {
            StartCoroutine(DashCooldown());
            StartCoroutine(DashMovement());
        }

        private void Move()
        {
            Vector3 targetSpeed = cameraRelativeMovement * data.runMaxSpeed;
            Vector3 speedDif = targetSpeed - rb.velocity;
            Vector3 movement = speedDif * (targetSpeed == Vector3.zero ? data.runDeceleration : data.runAcceleration); //insert here * blend vector
            if(cameraRelativeMovement == Vector3.zero && rb.velocity.magnitude <= 0.02f)
            {
                rb.velocity = Vector3.zero;
            }
            else
            {
                rb.AddForce(movement, ForceMode.Acceleration);
            }
        }
        private IEnumerator DashMovement()
        {
            //lock player movement
            lockMovement = true;
        
            //reset velocity for more controlled dashspeed
            rb.velocity = Vector3.zero;
        
            //add velocity to player (dashSpeed)
            rb.velocity = cameraRelativeMovement != Vector3.zero ? cameraRelativeMovement * data.dashSpeed : Vector3.forward * data.dashSpeed;
        
            //for short duration (dashDuration)
            yield return new WaitForSeconds(data.dashDuration);

            //set player movement at max speed
            rb.velocity = data.resetVelocityAfterDash ? Vector3.zero : cameraRelativeMovement * data.runMaxSpeed;

            //unlock player movement
            lockMovement = false;
        }

        private IEnumerator DashCooldown()
        {
            dashAvailable = false;
            yield return new WaitForSeconds(data.dashCooldown);
            dashAvailable = true;
        }

        public Rigidbody GetRB()
        {
            return rb;
        }
    }
}
