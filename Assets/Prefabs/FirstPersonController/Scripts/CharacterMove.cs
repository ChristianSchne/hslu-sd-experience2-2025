using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMove : MonoBehaviour
{
    CharacterController characterController;
    Vector3 playerVelocity = Vector3.zero;
    public float speed = 3f;
    public float gravity = 9.81f;
    public float jumpHeight = 4f;
    bool isGrounded;
    float defaultSlopeLimit;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        defaultSlopeLimit = characterController.slopeLimit;
    }

    void Update()
    {
        if(isGrounded != characterController.isGrounded){
            isGrounded = characterController.isGrounded;
            //Uncomment to fix mesh collider jump glitch
            //characterController.slopeLimit = isGrounded? defaultSlopeLimit : 90;
        }

        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");
        Vector3 motion = transform.forward * yMove + transform.right * xMove;
        characterController.Move(motion * Time.deltaTime * speed);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(3 * gravity * jumpHeight);
        }

        if(isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
        }

        playerVelocity.y -= gravity * Time.deltaTime;

        characterController.Move(playerVelocity * Time.deltaTime);
    }
  
}
