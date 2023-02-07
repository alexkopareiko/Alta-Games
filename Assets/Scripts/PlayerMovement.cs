using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float jumpHeight = 2f;
    [SerializeField] float speed = 2f;
    [SerializeField] float gravity = -50f;
    [SerializeField] CharacterController characterController;
    bool move = false;
    Vector3 startPosition;
    Vector3 toPosition;
    Vector3 velocity;
    bool isGrounded;
    bool isArrived = false;


    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (move)
        {
            CheckGround();

            if (isArrived && isGrounded) move = false; 

            // move forward
            if(!isArrived)
            {
                characterController.Move(transform.forward * speed * Time.deltaTime);
            }

            // gravity
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            // jump
            if (isGrounded)
            {
                velocity.y += Mathf.Sqrt(-jumpHeight * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            characterController.Move(velocity * Time.deltaTime);

            // check
            if (transform.position.z >= toPosition.z)
            {
                isArrived = true;
            }

            //Debug.Log("move " + move);
        }
    }

    void CheckGround()
    {
        isGrounded = characterController.isGrounded;
        //Debug.Log("isGrounded " + isGrounded);
    }

    public void MoveTo(Vector3 _to)
    {
        startPosition = transform.position;
        toPosition = _to;
        move = true;
        isArrived = false;
    }
}
