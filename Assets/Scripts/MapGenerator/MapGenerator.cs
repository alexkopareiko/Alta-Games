using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {

    public ObstacleDisplay obstacleDisplay;

    public int mapWidth;
	public int mapHeight;
	public float noiseScale;

	public int octaves;
	[Range(0,1)]
	public float persistance;
	public float lacunarity;

	public int seed;
	public Vector2 offset;

	public bool autoUpdate;
	public bool dataFromInsector;

    private void Start()
    {
		GenerateMap();
    }

    public void GenerateMap() {
		if(!dataFromInsector)
		{
			offset = new Vector2(Random.Range(0, 100), Random.Range(0, 100));

        }
		float[,] noiseMap = Noise.GenerateNoiseMap (mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);


		/*MapDisplay display = FindObjectOfType<MapDisplay> ();
		display.DrawNoiseMap (noiseMap);*/

        obstacleDisplay.DisplayObstacles(noiseMap);

    }

    void OnValidate() {
		if (mapWidth < 1) {
			mapWidth = 1;
		}
		if (mapHeight < 1) {
			mapHeight = 1;
		}
		if (lacunarity < 1) {
			lacunarity = 1;
		}
		if (octaves < 0) {
			octaves = 0;
		}
	}

}