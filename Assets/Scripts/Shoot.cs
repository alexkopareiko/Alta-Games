using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] Rigidbody m_rigidbody;
    [SerializeField] float minScale = 0.1f;
    [SerializeField] float force = 0.1f;
    [SerializeField] Transform playerTrans;

    public void Initialize(float _range)
    {
        transform.localScale = playerTrans.localScale * _range;
        if(transform.localScale.x <= minScale)
        {
            Debug.Log("MIN SCALE");
            return;
        }
        m_rigidbody.AddForce(Vector3.forward * force, ForceMode.Impulse);
        gameObject.SetActive(true);
    }
}
