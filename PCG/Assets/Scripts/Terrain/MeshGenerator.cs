// Followed tutorial by Brackeys
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Generates Mesh based on input values
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class MeshGenerator : MonoBehaviour
{
    [Header("Mesh Dimensions")]
    public int width;
    public int length;

    [Header("Mesh Details"), Tooltip("Controls size of each quad (Useful for large meshes with less vertices)")]
    public bool isWater = false;
    public bool gradualTerrainRise = false;
    public float meshScaling = 1.0f;
    public float perlinStrength;
    public Vector2 perlinOffset;

    Mesh mesh;              // New Mesh
    Vector3[] vertices;     // Mesh vertices
    int[] triangles;        // Mesh triangles

    private void Awake()
    {
        perlinOffset.x = Random.Range(0.0f, 1.0f);
        perlinOffset.y = Random.Range(0.0f, 1.0f);
    }

    private void Start()
    {
        mesh = new Mesh();
        mesh.name = "Terrain Mesh";
        GetComponent<MeshFilter>().mesh = mesh;

        GenerateMesh();
        ApplyMesh();
    }

    private void FixedUpdate()
    {
        if (isWater)
        {
            perlinOffset.x += 0.01f;
            GenerateMesh();
            ApplyMesh();
        }

    }

    // Generate Mesh to use
    void GenerateMesh()
    {
        // Number of vertices = dimension + 1 
        /// e.g. 2 squares -> 3 vertices
        vertices = new Vector3[(width + 1) * (length + 1)];

        // Loop through all vertices (<= +1)
        int index = 0;
        int xPos = 0;
        int zPos = 0;
        for (int z = 0; z <= length; z++)
        {
            for (int x = 0; x <= width; x++)
            {

                float perlin = Mathf.PerlinNoise(x + perlinOffset.x, z + perlinOffset.y) * perlinStrength;
                perlin += (perlin * 2) - 1;

                if(gradualTerrainRise)
                    vertices[index] = new Vector3(x * meshScaling, z * perlin, z * meshScaling);
                else
                    vertices[index] = new Vector3(x * meshScaling, perlin, z * meshScaling);


                index++;
                xPos++;
            }
            zPos++;
            xPos = 0;
        }

        // Triangles is the size of verts * 6 for each total verts for 1 quad
        triangles = new int[width * length * 6];

        // Index of current vert and current set of triangle verts
        int vertex = 0;
        int triVerts = 0;

        // Loop through every vert and add to corresponding triangle
        for (int z = 0; z < length; z++)
        {
            for (int x = 0; x < width; x++)
            {
                /// triVerts:   Scaled by 6 each iteration as one quad has 6 vertices
                /// vertex:     Scaled by 1 each iteration as each quad is shifted to the right each loop
                triangles[triVerts + 0] = vertex + 0;
                triangles[triVerts + 1] = vertex + width + 1;
                triangles[triVerts + 2] = vertex + width + 2;
                triangles[triVerts + 3] = vertex + 0;
                triangles[triVerts + 4] = vertex + width + 2;
                triangles[triVerts + 5] = vertex + 1;

                vertex++;
                triVerts += 6;
            }
            // Prevent mesh width end looping
            vertex++;
        }
    }

    // Apply generated Mesh
    void ApplyMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

    // Paramter clamping
    private void OnValidate()
    {
        if (width < 1)
            width = 1;
        if (length < 1)
            length = 1;
        if (meshScaling < 1)
            meshScaling = 1.0f;
    }
}
