using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public GameObject blockPrefab;         // Prefab de un cubo
    public GameObject deepBlockPrefab;     // Prefab para los bloques debajo de la capa 5
    public int width = 16;                 // Ancho del chunk
    public int height = 10;                // Altura m�xima del terreno
    public float scale = 0.1f;             // Escala del ruido Perlin

    // A�adimos una semilla para cambiar la generaci�n del mundo
    public float seed = 0f;

    void Start()
    {
        GenerateWorld();
    }

    void GenerateWorld()
    {
        // Configuramos la semilla del ruido Perlin
        Random.InitState((int)seed);

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < width; z++)
            {
                // Aplicamos el ruido Perlin para calcular la altura
                float noise = Mathf.PerlinNoise(x * scale + seed, z * scale + seed);
                int terrainHeight = Mathf.FloorToInt(noise * height);

                // Creamos bloques hasta la altura calculada por el ruido
                for (int y = 0; y < terrainHeight; y++)
                {
                    Vector3 pos = new Vector3(x, y, z);
                    
                    // Cambiar el tipo de bloque dependiendo de la altura
                    if (y >= 5)
                    {
                        // Usar un bloque diferente para capas debajo de la capa 5
                        Instantiate(deepBlockPrefab, pos, Quaternion.identity);
                    }
                    else
                    {
                        // Usar el bloque normal para las capas superiores
                        Instantiate(blockPrefab, pos, Quaternion.identity);
                    }
                }
            }
        }
    }
}
