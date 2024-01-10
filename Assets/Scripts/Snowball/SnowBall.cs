using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SnowBall : MonoBehaviour
{

    public Terrain terrain;

    public float strenght;
    public int size;

    private void OnCollisionEnter(Collision collision)
    {
        var arroundStructure = Physics.OverlapSphere(gameObject.transform.position, 10.0f);
        bool nothingAround = true;
        foreach (var item in arroundStructure)
        {
            if (item.CompareTag("Object and House") || item.CompareTag("Player"))
                nothingAround = false; break;
        }
        if (nothingAround)
            TerraformTerrain(gameObject.transform.position, strenght, size);
        Destroy(gameObject);
    }

    private Mesh mesh;
    private Vector3[] vertices;

    private void TerraformTerrain(Vector3 position, float height, int radius)
    {
        TerrainData terrainData = terrain.terrainData;

        var hmWidth = terrainData.heightmapResolution;
        var hmHeight = terrainData.heightmapResolution;
        // get the normalized position of this game object relative to the terrain
        Vector3 tempCoord = (position - terrain.gameObject.transform.position);
        Vector3 coord;
        coord.x = tempCoord.x / terrainData.size.x;
        coord.y = tempCoord.y / terrainData.size.y;
        coord.z = tempCoord.z / terrainData.size.z;

        // get the position of the terrain heightmap where this game object is
        var posXInTerrain = (int)(coord.x * hmWidth);
        var posYInTerrain = (int)(coord.z * hmHeight);

        // we set an offset so that all the raising terrain is under this game object
        int offset = radius / 2;

        // get the heights of the terrain under this game object
        float[,] heights = terrainData.GetHeights(posXInTerrain - offset, posYInTerrain - offset, radius, radius);

        // we set each sample of the terrain in the size to the desired height
        for (int i = 0; i < radius; i++)
            for (int j = 0; j < radius; j++)
            {
                heights[i, j] = heights[i, j] + height;
                height /= 2;
            }

        // set the new height
        terrainData.SetHeights(posXInTerrain - offset, posYInTerrain - offset, heights);

    }
}
