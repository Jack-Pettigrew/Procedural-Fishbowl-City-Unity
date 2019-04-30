using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ProceduralRock : MonoBehaviour
{
    Mesh mesh;
    MeshRenderer rend;
    Vector3[] originalVerts;
    Vector3[] minVerts;
    List<Vector3> newVerts;
    int[] triangles;
    Vector3 centre;

    [Range(0, 2.0f)]
    public float vertexVariation = 1.0f;
    [Range(0.0f, 10.0f)]
    public float rockThreshold = 1.0f;

    private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        rend = GetComponent<MeshRenderer>();
    }

    private void Start()
    { 
        originalVerts = mesh.vertices;
        triangles = mesh.triangles;
        minVerts = mesh.vertices;

        for (int i = 0; i < minVerts.Length; i++)
        {
            minVerts[i] *= 0.1f;
        }

        newVerts = new List<Vector3>();

        CalculateMesh();

    }

    private void CalculateMesh()
    {

        newVerts.Clear();

        float scalePerlin = Random.Range(1, 1000);

        for (int i = 0; i < originalVerts.Length; i++)
        { 
            float perlin = Mathf.PerlinNoise(originalVerts[i].x + scalePerlin, originalVerts[i].y + scalePerlin);

            Vector3 newVertexPos = Vector3.Lerp(originalVerts[i] * rockThreshold, minVerts[i], perlin * vertexVariation);

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
        mesh.RecalculateTangents();
        mesh.RecalculateBounds();
    }

}
