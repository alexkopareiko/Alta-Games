using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathLine : MonoBehaviour
{
    [SerializeField] Transform playerTran;
    [SerializeField] Transform finishTran;
    [SerializeField] float startWidth = 1f;
    [SerializeField] float endWidth = 1f;
    [SerializeField] Material mat;

    Mesh mesh;
    MeshRenderer meshRenderer;
    Vector3 playerPos;
    Vector3 finishPos;

    private void Start()
    {
        gameObject.AddComponent<MeshFilter>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        Initialize();
    }

    public void Initialize()
    {
        gameObject.SetActive(true);

        startWidth = playerTran.localScale.x;
        // width correction
        startWidth *= 1.2f;

        meshRenderer.material = mat;

        mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();

        playerPos = playerTran.position;
        finishPos = finishTran.position;

        mesh.vertices = new Vector3[]
        {
            new Vector3(playerPos.x - startWidth/2, 0.01f, playerPos.z + 0.1f),
            new Vector3(playerPos.x + startWidth/2, 0.01f, playerPos.z + 0.1f),
            new Vector3(finishPos.x - endWidth/2, 0.01f, finishPos.z + 0.1f),
            new Vector3(finishPos.x + endWidth/2, 0.01f, finishPos.z + 0.1f),
        };

        mesh.triangles = new int[] {
            0, 3, 1, 2, 0, 3
        };

        mesh.normals = new Vector3[]
        {
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward
        };

        Vector2[] uv = new Vector2[]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1),
        };

        mesh.uv = uv;

    }
}
