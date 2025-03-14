using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{

    public GameObject blockPrefab; // Prefab de un cubo
    public int width = 16;
    public int height = 16;

    void Start()
    {
        GenerateWorld();
    }

    void GenerateWorld()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < width; z++)
            {
                for (int y = 0; y < height; y++)
                {
                    Vector3 pos = new Vector3(x, y, z);
                    Instantiate(blockPrefab, pos, Quaternion.identity);
                }
            }
        }
    }

}