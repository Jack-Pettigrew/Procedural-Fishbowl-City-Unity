using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Procedural Manager Class - determines Procedural Content Generation
public class ProceduralManager : MonoBehaviour
{
    [Header("Parent")]
    public GameObject buildingHolder;
    public Transform buildHolder;
    [Header("Buildings PCG"), Range(1, 200)]
    public int buildingAmount = 1;
    [Range(1, 50)]
    public int buildingsMaxMid = 1;
    public List<GameObject> buildingBases, buildingMids, buildingRoofs;

    [Header("Terrain PCG")]
    public float terrainWidth, terrainLength;
    private Terrain terrain;
    
    //public int pixW, pixH;          // W + H of texture in pixels
    //public float xOrg, yOrg;        // Origin of sampled area for PerlinNoise (moves sampled area)
    //public float perlinScale;       // Scales the amount of cycles PerlinNoise has to do (more = more noise)

    //private Texture2D noiseTex;
    //private Color[] pixel;
    //private Renderer rend;

    public GameObject quad;

    // Set Script specific elements
    void Awake()
    {
        
    }

    // Set Handles
    void Start()
    {
        // Terrain + Building Init
        TerrainInit();
        StartCoroutine(Build());

        //TerrainPCG();
    }

    // Get Terrain dimensions
    void TerrainInit()
    {
        terrain = FindObjectOfType<Terrain>();
        terrainWidth = terrain.terrainData.size.x;
        terrainLength = terrain.terrainData.size.z;
    }

    //void TerrainPCG()
    //{

    //    //rend = terrain.GetComponent<Renderer>();
    //    rend = quad.GetComponent<Renderer>();

    //    // Create new Texture to hold perlinNoise
    //    noiseTex = new Texture2D(pixH, pixH);
    //    // Create Color[] to hold color values for texture
    //    pixel = new Color[noiseTex.width * noiseTex.height];
    //    // Set main texture to new Texture
    //    //rend.material.mainTexture = noiseTex;
    //    rend.material.mainTexture = noiseTex;

    //    // For every pixel in noiseTex
    //    float y = 0.0f;
    //    while (y < noiseTex.height)
    //    {
    //        float x = 0.0f;
    //        while (x < noiseTex.width)
    //        {
    //            // Create Coords for Perlin Noise
    //            float xCoord = xOrg + x / noiseTex.width * perlinScale;
    //            float yCoord = yOrg + y / noiseTex.height * perlinScale;

    //            // Generate Perlin Noise + input to Color[] for pixels
    //            float perlinSample = Mathf.PerlinNoise(xCoord, yCoord);
    //            /// quick handed way of getting the index for the texture (instead of FOR loop)
    //            pixel[(int)y * noiseTex.width + (int)x] = new Color(perlinSample, perlinSample, perlinSample);
    //            x++;
    //        }
    //        y++;
    //    }

    //    // Copy colored pixels to texture
    //    noiseTex.SetPixels(pixel);
    //    noiseTex.Apply();

    //}

    // Coroutine bulding PCG elements

    IEnumerator Build()
    {
        Quaternion blenderRotationOffest = Quaternion.Euler(-90.0f, 0.0f, 0.0f);

        // Creates the specified amount of Buildings
        for (int i = 0; i < buildingAmount; i++)
        {
            // Spawn Holder for Buildings
            GameObject buildingHolderer = Instantiate(buildingHolder, buildHolder.transform) as GameObject;
            buildingHolderer.name = "Building " + i;

            // Index for random sections
            int index = Random.Range(0, buildingBases.Count);

            // Pos of each building
            Vector3 pos = new Vector3(terrain.transform.position.x + Random.Range(0, terrainWidth), 0, terrain.transform.position.z + Random.Range(0, terrainLength));
            pos.y += Terrain.activeTerrain.SampleHeight(pos);

            // Spawn Base
            Instantiate(buildingBases[index], pos, blenderRotationOffest, buildingHolderer.transform);

            pos.y += buildingBases[index].GetComponent<Renderer>().bounds.size.y;

            // Spawn Mids
            for (int j = 0; j < Random.Range(1, buildingsMaxMid + 1); j++)
            {
                Instantiate(buildingMids[index], pos, blenderRotationOffest, buildingHolderer.transform);

                pos.y += buildingMids[index].GetComponent<Renderer>().bounds.size.y;
            }

            // Spawn Roof
            Instantiate(buildingRoofs[index], pos, blenderRotationOffest, buildingHolderer.transform);

            yield return new WaitForSeconds(0.1f);
        }

        yield return null;
    }

}
