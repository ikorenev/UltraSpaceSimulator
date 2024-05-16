using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidsManager : MonoBehaviour
{
    public GameObject AsteroidPrefab;

    public int NumberOfAsteroidOnAxisX = 10;
    public int NumberOfAsteroidOnAxisY = 10;
    public int NumberOfAsteroidOnAxisZ = 10;

    public int GridSpacing = 10;

    private void Start()
    {
      for (int i = 0; i < NumberOfAsteroidOnAxisX; i++)
        {
            for(int j = 0; j < NumberOfAsteroidOnAxisY; j++) {
            for(int k = 0; k < NumberOfAsteroidOnAxisZ; k++)
                {
                    InstantiateAsteroids(i, j, k);
                }
            }
        }  
    }

    private void InstantiateAsteroids(int x, int y, int z)
    {
        Instantiate(AsteroidPrefab, new Vector3(
            transform.position.x + x * GridSpacing + OffsetAsteroid(),
            transform.position.y + y * GridSpacing + OffsetAsteroid(),
            transform.position.z + z * GridSpacing + OffsetAsteroid()),
            Quaternion.identity, transform);
    }

    private float OffsetAsteroid()
    {
        return Random.Range(-GridSpacing / 3f, GridSpacing / 3f);
    }
}
