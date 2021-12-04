using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace sidz.wogame
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Player Settings")]
        public float fMovementSpeed = 3f;
        public Rigidbody rbAttached;
        public float fJumpingForce = 300f;

        //Movements
        private float fHorizontalAxis;
        private float fVerticalAxis;
        private Vector3 vCurrentVelocity;

        //Jumping
        private bool bJumpStarted;
        private bool bIsAlreadyJumping;
      

        void Start()
        {
            rbAttached = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            fHorizontalAxis = Input.GetAxis("Horizontal");
            fVerticalAxis = Input.GetAxis("Vertical");
            vCurrentVelocity = rbAttached.velocity;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (bJumpStarted == false)
                {
                    bJumpStarted = true;
                    bIsAlreadyJumping = false;
                }
            }
        }
        // Update is called once per frame
        void FixedUpdate()
        {
            if (fHorizontalAxis!=0)
            {
                rbAttached.velocity = new Vector3(fMovementSpeed* fHorizontalAxis, vCurrentVelocity.y,vCurrentVelocity.z);
            }
            if (bJumpStarted == true && bIsAlreadyJumping == false)
            {
                bIsAlreadyJumping = true;
                rbAttached.AddForce(Vector3.up*fJumpingForce , ForceMode.Force);
            }

        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == GameTags.c_strWall)
            {
                bIsAlreadyJumping = false;
                bJumpStarted = false;
                Debug.Log("Hit by wall", collision.gameObject);
            }
       
        }
    }
}
