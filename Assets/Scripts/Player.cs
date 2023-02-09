using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float minScale = 0.1f;
    [SerializeField] Shoot shoot;



    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("obstacle"))
        {
            GameManager.instance.GameOver(); 
        }
        else if (hit.collider.CompareTag("finish"))
        {
            GameManager.instance.Win(); 
        }
    }


public void SetScale(float _range)
    {
        transform.localScale = transform.localScale - transform.localScale * _range;
        if (transform.localScale.x <= minScale)
        {
            Debug.Log("MIN SCALE");
            GameManager.instance.GameOver();
            return;
        }
        shoot.Initialize(_range);

    }
}
