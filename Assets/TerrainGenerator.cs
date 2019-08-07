/**
 * wilhsie 2019 august
 * code here is derrived from this youtube video
 * https://www.youtube.com/watch?v=vFvwyu_ZKfU
 */

using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int depth = 20;

    public int width = 256;
    public int height = 256;

    public float scale = 20f;

    public float offsetX = 100f;
    public float offsetY = 100f;

    void Start()
    {
        offsetX = Random.Range(0f, 9999f);
        offsetY = Random.Range(0f, 9999f);
    }

    void Update()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = generateTerrain(terrain.terrainData);

        offsetX -= Time.deltaTime * 5;
    }

    // set size of terrain data and populate with heights
    TerrainData generateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;

        terrainData.size = new Vector3(width, depth, height);

        terrainData.SetHeights(0, 0, generateHeights());

        return terrainData;
    }

    // create matrix of float heights
    float[,] generateHeights()
    {
        float[,] heights = new float[width, height];

        for(int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // set to some perlin noise value
                heights[x, y] = calculateHeight(x, y);
            }
        }

        return heights;
    }

    // calculate heights based on some scale and perlin noise (??)
    float calculateHeight(int x, int y)
    {
        float xCoord = (float) x / width * scale + offsetX;
        float yCoord = (float) y / height * scale + offsetY;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
