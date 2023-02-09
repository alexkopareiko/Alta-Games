using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDisplay : MonoBehaviour
{
    [SerializeField] float left;
    [SerializeField] float right;
    [SerializeField] float top;
    [SerializeField] float bottom;
    [SerializeField] float radiusToAvoid = 2f;
    [SerializeField] GameObject obstaclePref;
    [SerializeField] Transform playerTrans;
    [SerializeField] Transform finishTrans;

    GameObject obstacle;
    GameObject obstacles;

    public void DisplayObstacles(float[,] noiseMap) 
    {
        int width = noiseMap.GetLength(0);
        int height = noiseMap.GetLength(1);

        Vector3 position;
        float distance;


        float delimiterHor = (right - left) / (width);
        float delimiterVert = (top - bottom) / (height);

        obstacles = new GameObject("obstacles");

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // hide some
                if (noiseMap[x, y] < 0.5f) continue;
                //Debug.Log("noiseMap[x, y] " + noiseMap[x, y]);
                position = new Vector3(left + x * delimiterHor, 0, bottom + y * delimiterVert);
                distance = Vector3.Distance(playerTrans.position, position);
                if (distance < radiusToAvoid) continue;
                distance = Vector3.Distance(finishTrans.position, position);
                if (distance < radiusToAvoid) continue;
                obstacle = Instantiate(obstaclePref, position, Quaternion.identity);
                obstacle.transform.localScale = obstacle.transform.localScale * noiseMap[x, y] * 2;
                obstacle.transform.SetParent(obstacles.transform);
            }
        }
    }
}
