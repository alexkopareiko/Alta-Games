using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float jumpHeight = 2f;
    [SerializeField] float speed = 2f;
    [SerializeField] float gravity = -50f;
    [SerializeField] CharacterController characterController;
    [SerializeField] PathLine pathLine;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask doorTriggerLayer;

    Vector3 toPosition;
    Vector3 velocity;
    bool move = false;
    bool isGrounded;
    bool isArrived = false;
    WaitForSeconds waitMove = new WaitForSeconds(1.2f);


    private void Start()
    {
        
    }

    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (move && !GameManager.instance.gameIsOver)
        {
            CheckGround();

            if (isArrived && isGrounded)
            {
                move = false;
                pathLine.Initialize();
                return;
            }

            // move forward
            if (!isArrived)
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

        }
    }

    void CheckGround()
    {
        isGrounded = characterController.isGrounded;
        //isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundLayer, QueryTriggerInteraction.Ignore);
        //Debug.Log("isGrounded " + isGrounded);
    }

    IEnumerator MoveTo(Vector3 _to, bool _call)
    {
        yield return waitMove;
        Vector3 to = _to;
        if (CheckIfPathFree())
        {
            to = GameManager.instance.GetFinishObj().transform.position;
        }
        toPosition = to;
        move = true;
        isArrived = false;

    }

    bool CheckIfPathFree()
    {
        RaycastHit hit;
        float radius = transform.localScale.x * 1f;
        Vector3 from = transform.position;
        from.z = from.z + 2 * radius;
        from.y = from.y + radius + 0.5f;

        // ignore door trigger block
        int layerMask = 1 << (int)doorTriggerLayer;
        layerMask = ~layerMask;

        if (Physics.SphereCast(from, radius, transform.forward * 100, out hit, 100))
        //if (Physics.Raycast(from,  transform.forward * 100, out hit))
        {
            //Debug.Log("name " + hit.collider.gameObject.transform.parent.name);
            if (hit.collider.CompareTag("finish"))
            {
                //Debug.Log("Path is free ");
                return true;
            }
        }
        return false;
    }

    public void MoveTo(Vector3 _to)
    {
        StartCoroutine(MoveTo(_to, true));
    }

    void OnDrawGizmosSelected()
    {
        float radius = transform.localScale.x * 1f;
        Vector3 from = transform.position;
        from.z = from.z + 2 * radius;
        from.y = from.y + radius + 0.2f;

        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(from, radius);
    }


}
