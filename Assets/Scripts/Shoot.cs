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
    WaitForSeconds hideDelay = new WaitForSeconds(0.5f);

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("obstacle"))
        {
            Collider[] hitColliders = Physics.OverlapSphere(
                transform.position, 
                transform.localScale.x * damageRadiusMulti, 
                obstacleMask);
            foreach (var hitCollider in hitColliders)
            {
                hitCollider.SendMessage("ApplyDamage");
            }
            StartCoroutine(HideMe());
        }
    }

    public void Initialize(float _range)
    {
        transform.localScale = playerMovement.transform.localScale * _range;
        
        gameObject.SetActive(true);
        m_rigidbody.AddForce(Vector3.forward * force, ForceMode.Impulse);
        pathLine.gameObject.SetActive(false);
    }

    IEnumerator HideMe()
    {
        yield return hideDelay;
        playerMovement.MoveTo(transform.position);
        gameObject.SetActive(false);
    }
}
