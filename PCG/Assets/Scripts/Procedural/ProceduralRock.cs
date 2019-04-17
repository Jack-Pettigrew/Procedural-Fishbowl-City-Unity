using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ProceduralRock : MonoBehaviour
{
    Mesh mesh;
    Vector3[] originalVerts;
    List<Vector3> newVerts;
    int[] triangles;
    Vector3 centre;

    [Range(0, 2.5f)]
    public float vertexStrength = 1.0f;

    [Range(0.0f, 5.0f)]
    public float rockScale = 0.0f;

    [Range(0.01f, 1.0f)]
    public float rockRoundness = 1.0f;

    // Get Mesh
    // Get Perlin Noise for Vertex positions
    // Push/Pull vertex + scalar/dampen against centre
    // Smoothen/Sharpen Vertex point parameters

    private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    private void Start()
    {
        originalVerts = mesh.vertices;
        triangles = mesh.triangles;

        newVerts = new List<Vector3>();

        CalculateMesh();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            CalculateMesh();
    }

    private void CalculateMesh()
    {
        newVerts.Clear();

        float scalePerlin = Random.Range(0, 100000);

        for (int i = 0; i < originalVerts.Length; i++)
        {
            float perlin = PerlinNoise3D(originalVerts[i].x + scalePerlin, originalVerts[i].y + scalePerlin, originalVerts[i].z + scalePerlin);

            Vector3 newVertexPos = Vector3.Lerp(originalVerts[i] * rockScale, transform.position, (perlin * vertexStrength) * rockRoundness);

            newVerts.Add(newVertexPos);
        }

        UpdateMesh();
    }

    // Takes Perlin Noise 2D and averages it in 3D space
    public float PerlinNoise3D(float x, float y, float z)
    {

        float AB = Mathf.PerlinNoise(x, y);
        float BC = Mathf.PerlinNoise(y, z);
        float AC = Mathf.PerlinNoise(x, z);

        float BA = Mathf.PerlinNoise(y, z);
        float CB = Mathf.PerlinNoise(z, y);
        float CA = Mathf.PerlinNoise(z, x);

        float sum = AB + BC + AC + BA + CB + CA;
        return sum / 6.0f;
        
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = newVerts.ToArray();
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }

}
