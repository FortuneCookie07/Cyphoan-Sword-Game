using UnityEngine;

public class MopGenerator : MonoBehaviour
{
    Mesh mesh;

    Vector3 [] vertices;
    int[] triangles;

    public int width = 100;
    public int height = 100;
    public float scale = 20f;
    public int octaves = 4;
    public float persistence = 0.5f;
    public float lacunarity = 2f;

    private MeshFilter meshFilter;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        //meshFilter = GetComponent<MeshFilter>();
        //meshFilter.mesh = GenerateTerrainMesh();
        GenerateTerrainMesh();
        Debug.Log("generating terrain mesh");
        UpdateMesh();
        Debug.Log("updating mesh");
    }

    void GenerateTerrainMesh()
    {
        //Mesh mesh = new Mesh();

        vertices = new Vector3[width * height];
        triangles = new int[(width - 1) * (height - 1) * 6];

        float[,] heights = GenerateHeights();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int index = x * height + y;
                vertices[index] = new Vector3(x, heights[x, y], y);
            }
        }

        int triangleIndex = 0;

        for (int x = 0; x < width - 1; x++)
        {
            for (int y = 0; y < height - 1; y++)
            {
                int topLeft = x * height + y;
                int topRight = (x + 1) * height + y;
                int bottomLeft = x * height + (y + 1);
                int bottomRight = (x + 1) * height + (y + 1);

                triangles[triangleIndex++] = topLeft;
                triangles[triangleIndex++] = topRight;
                triangles[triangleIndex++] = bottomLeft;

                triangles[triangleIndex++] = bottomLeft;
                triangles[triangleIndex++] = topRight;
                triangles[triangleIndex++] = bottomRight;
            }
        }

        //UpdateMesh();
        Debug.Log("successfully generated mesh");
    }

    private float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = GenerateHeight(x, y);
            }
        }

        return heights;
    }

    private float GenerateHeight(int x, int y)
    {
        float amplitude = 1f;
        float frequency = 1f;
        float noiseHeight = 0f;

        for (int i = 0; i < octaves; i++)
        {
            float sampleX = x / scale * frequency;
            float sampleY = y / scale * frequency;
            float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2f - 1f;

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

        mesh.RecalculateNormals();
    }
}