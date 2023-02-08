using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float jumpHeight = 2f;
    [SerializeField] float speed = 2f;
    [SerializeField] float gravity = -50f;
    [SerializeField] CharacterController characterController;
    [SerializeField] PathLine pathLine;
    [SerializeField] LayerMask groundLayer;

    Vector3 toPosition;
    Vector3 velocity;
    bool move = false;
    bool isGrounded;
    bool isArrived = false;
    WaitForSeconds waitMove = new WaitForSeconds(1);


    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (move)
        {
            CheckGround();

            if (isArrived && isGrounded)
            {
                move = false;

            }

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
                pathLine.Initialize();
            }

        }
    }

    void CheckGround()
    {
        //isGrounded = characterController.isGrounded;
        isGrounded = Physics.CheckSphere(transform.position, 0.05f, groundLayer, QueryTriggerInteraction.Ignore);
        //Debug.Log("isGrounded " + isGrounded);
    }

    public void MoveTo(Vector3 _to)
    {
        toPosition = _to;
        move = true;
        isArrived = false;
    }
}
