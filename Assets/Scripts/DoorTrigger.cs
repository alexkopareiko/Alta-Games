using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] GameObject doorObj;
    bool isActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !isActivated)
        {
            Activate();
        }
    }

    public void Activate()
    {
        LeanTween.rotateY(doorObj, -70, 2).setEaseInElastic();
        isActivated = true;
    }
}
