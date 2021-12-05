using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace sidz.finalbuild
{

    public class BPlayerController : MonoBehaviour
    {
        [Header("Controller")]
        public LevelManager levelManager;
        [SerializeField] private CharacterController controller;
        private Vector3 playerVelocity;
        private bool groundedPlayer;
        [SerializeField] private float playerSpeed = 2.0f;
        [SerializeField] private float jumpHeight = 1.0f;
        [SerializeField] private float gravityValue = -9.81f;

        private void Start()
        {
           
        }
        void OnControllerColliderHit(ControllerColliderHit hit)
        {
            var temp_IntComp = hit.gameObject.GetComponent<InteractaleType>();
            if(temp_IntComp!=null)
            levelManager.Level_OnPlayerInteracted(temp_IntComp);
        }
        void Update()
        {
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            controller.Move(move * Time.deltaTime * playerSpeed);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            // Changes the height position of the player..
            if (Input.GetButtonDown("Jump") && groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }
    }
}