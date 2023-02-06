using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLine : MonoBehaviour
{
    [SerializeField] LineRenderer line;
    [SerializeField] Transform playerTran;
    [SerializeField] Transform finishTran;
    [SerializeField] float startWidth = 1;
    [SerializeField] float endWidth = 1;


    private void Start()
    {
        DrawLine();
        line.enabled = true;
    }

    public void DrawLine()
    {
        line.SetPosition(0, playerTran.position);
        line.SetPosition(1, finishTran.position);
        line.startWidth = startWidth;
        line.endWidth = endWidth;
    }
}
