using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] Rigidbody m_rigidbody;
    [SerializeField] float force = 0.1f;
    [SerializeField] PathLine pathLine;
    [SerializeField] float damageRadiusMulti = 5f;
    [SerializeField] LayerMask obstacleMask;
    [SerializeField] PlayerMovement playerMovement;
    float range;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        m_rigidbody.velocity = transform.forward * force;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("obstacle"))
        {

            Collider[] hitColliders = Physics.OverlapSphere(
                transform.position,
                range * damageRadiusMulti, 
                obstacleMask);
            foreach (var hitCollider in hitColliders)
            {
                hitCollider.SendMessage("ApplyDamage");
            }
            gameObject.SetActive(false);
            playerMovement.MoveTo(transform.position);
        }
        if(collision.collider.CompareTag("finish"))
        {
            gameObject.SetActive(false);
            playerMovement.MoveTo(transform.position);

            //GameObject finish = GameManager.instance.GetFinishObj();
            //playerMovement.MoveTo(finish.transform.position);
        }
    }

    public void Initialize(float _range)
    {
        transform.localScale = playerMovement.transform.localScale * _range;
        range = _range;
        gameObject.SetActive(true);
        pathLine.gameObject.SetActive(false);
    }
}
