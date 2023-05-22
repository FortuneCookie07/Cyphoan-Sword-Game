using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MopGeneratorV2 : MonoBehaviour
{
    Mesh mesh;

    Vector3 [] vertices;
    int[] triangles;
    Color[] colors;

    public int xSize = 100;
    public int zSize = 100;

    public float perlinScale = 20f;
    public float offsetX = 100f;
    public float offsetZ = 100f;

    public int octaves = 4;
    public float persistence = 0.5f;
    public float lacunarity = 2f;

    public Gradient gradient;

    float minTerrainHeight;
    float maxTerrainHeight;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        perlinScale = Random.Range(15f, 30f);
        offsetX = Random.Range(0f, 99999f);
        offsetZ = Random.Range(0f, 99999f);

        CreateShape();
        UpdateMesh();
    }

    void Update()
    {
        //UpdateMesh();
    }

    void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        float[,] heights = GenerateHeights();

        float maxHeight = float.MinValue;
        float minHeight = float.MaxValue;

        int Width = heights.GetLength(0);
        int Height = heights.GetLength(1);

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                int i = z * xSize + x;
                vertices[i] = new Vector3(x, heights[x, z], z);
                //Debug.Log(vertices[i]);
                //Debug.Log(heights);
            }
        }

        triangles = new int[xSize * zSize * 6];

        int triangleIndex = 0;

        for (int x = 0; x < zSize - 1; x++)
        {
            for (int y = 0; y < xSize - 1; y++)
            {
                int topLeft = x * xSize + y;
                int topRight = (x + 1) * xSize + y;
                int bottomLeft = x * xSize + (y + 1);
                int bottomRight = (x + 1) * xSize + (y + 1);

                triangles[triangleIndex++] = topLeft;
                triangles[triangleIndex++] = topRight;
                triangles[triangleIndex++] = bottomLeft;

                triangles[triangleIndex++] = bottomLeft;
                triangles[triangleIndex++] = topRight;
                triangles[triangleIndex++] = bottomRight;
            }
        }

        colors = new Color[vertices.Length];

        for (int i = 0, z = 0; z < vertices.Length; z++)
        {
            float terrainHeight = Mathf.InverseLerp(minTerrainHeight, maxTerrainHeight, vertices[i].y);
            colors[i] = gradient.Evaluate(terrainHeight);
            i++;
        }

        for (int j = 0; j < Width; j++)
        {
            for (int k = 0; k < Height; k++)
            {
                float heightValue = heights[j, k];

                if (heightValue > maxHeight)
                    maxHeight = heightValue;
                if (heightValue < minHeight)
                    minHeight = heightValue;
            }
        }
        //Debug.Log("Maximum height: " + maxHeight);
        //Debug.Log("Minimum height: " + minHeight);
    }

    private float[,] GenerateHeights()
    {
        float[,] heights = new float[xSize, zSize];

        for (int x = 0; x < xSize; x++)
        {
            for (int z = 0; z < zSize; z++)
            {
                heights[x, z] = GenerateHeight(x, z);
            }
        }
        return heights;
    }

    private float GenerateHeight(int x, int z)
    {
        float amplitude = 4f;
        float frequency = 1f;
        float noiseHeight = 0f;

        for (int i = 0; i < octaves; i++)
        {
            float sampleX = x / perlinScale * frequency;
            float sampleY = z / perlinScale * frequency;
            float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2f - 0.5f;

            noiseHeight += perlinValue * amplitude;

            amplitude *= persistence;
            frequency *= lacunarity;
        }

        //Debug.Log("private float GenerateHeight(int x, int y)");
        return noiseHeight;
    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.colors = colors;

        mesh.RecalculateNormals();
    }
}
