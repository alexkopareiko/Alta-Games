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


    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (move)
        {
            CheckGround();

            // move forward
            characterController.Move(transform.forward * speed * Time.deltaTime);

            // gravity
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            // jump
            if (isGrounded)
            {
                velocity.y += Mathf.Sqrt(jumpHeight * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            characterController.Move(velocity * Time.deltaTime);

            // check
            if (transform.position == toPosition)
            {
                move = false;
            }

            Debug.Log("move " + move);
        }
    }

    void CheckGround()
    {
        isGrounded = characterController.isGrounded;
    }

    public void MoveTo(Vector3 _to)
    {
        startPosition = transform.position;
        toPosition = _to;
        move = true;
    }
}
