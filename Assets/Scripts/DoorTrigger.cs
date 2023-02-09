using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] GameObject doorObj;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Activate();
        }
    }

    public void Activate()
    {
        Vector3 downTo = doorObj.transform.position;
        downTo.y = -0.89f;
        LeanTween.move(doorObj, downTo, 2);
    }
}
