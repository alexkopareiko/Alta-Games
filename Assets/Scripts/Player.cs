using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float minScale = 0.1f;
    [SerializeField] Shoot shoot;

    public void SetScale(float _range)
    {
        transform.localScale = transform.localScale - transform.localScale * _range;
        if (transform.localScale.x <= minScale)
        {
            Debug.Log("MIN SCALE");
            return;
        }
        shoot.Initialize(_range);

    }
}
