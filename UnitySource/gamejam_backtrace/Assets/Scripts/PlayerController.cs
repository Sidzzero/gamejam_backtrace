using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace sidz.wogame
{
    public class PlayerController : MonoBehaviour
    {

        public ePlayerStates currentState = ePlayerStates.Idle;
        public ePlayerStates prevState  = ePlayerStates.Init;
        [Header("Player Movement Settings")]
        public float fMovementSpeed = 3f;
        public Rigidbody rbAttached;
        public float fJumpingForce = 300f;

        [Header("Animations")]
        public Animator acController;

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
                    UpdateState(ePlayerStates.Jump);
                }
            }
            if (bJumpStarted == false)
            {
                if (fHorizontalAxis == 0)
                {
                    UpdateState(ePlayerStates.Idle);
                }
                else
                {
                    UpdateState(ePlayerStates.Move);
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

        #region GAME_RELATED
        public void UpdateState(ePlayerStates a_newState)
        {
            if (a_newState == currentState)
            {
               // Debug.Log("Player is same state already:"+currentState);
                return;
            }
            prevState = currentState;
            currentState = a_newState;
            switch (currentState)
            {
                case ePlayerStates.Idle:
                    break;
                case ePlayerStates.Move:
                    break;
                case ePlayerStates.Jump:
                    break;
                case ePlayerStates.Dead:
                    break;
                case ePlayerStates.Shooting:
                    break;
                case ePlayerStates.Init:
                    Debug.LogError("Someone tried to play this invalid State ");
                    break;
            }
        }
        #endregion GAME_RELATED
    }
}
