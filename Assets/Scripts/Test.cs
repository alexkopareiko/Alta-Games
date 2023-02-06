using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Debug.Log("UVS");
        foreach(var uv in mesh.uv)
        {
            Debug.Log(uv);
        }
        Debug.Log("TRIANLES");
        foreach (var triangle in mesh.triangles)
        {
            Debug.Log(triangle);
        }Debug.Log("NORMALS");
        foreach (var normal in mesh.normals)
        {
            Debug.Log(normal);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
