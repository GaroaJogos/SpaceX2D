﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyShip;

    [SerializeField]
    private GameObject asteroide;

    [SerializeField]
    private GameObject[] powerupIcons;

    public bool SpawnEnemyShip = true;
    public bool SpawnAsteroide = true;
    public bool SpawnPowerupIcons = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
        StartCoroutine(PowerupSpawn());
        StartCoroutine(AsteroidSpawn());
    }

    IEnumerator AsteroidSpawn()
    {
        yield return new WaitForSeconds(10f);

        while (SpawnAsteroide)
        {
            for(int i = 0; i< 5; ++i)
            {
                if (!SpawnAsteroide)
                    break;

                Instantiate(asteroide, new Vector3(Random.Range(-10f, 10f), 6f, 0f), Quaternion.identity);
                yield return new WaitForSeconds(0.3f);
            }

            yield return new WaitForSeconds(40f);
        }
    }

    IEnumerator EnemySpawn()
    {
        while (SpawnEnemyShip)
        {
            for (int i = 0; i < 3; ++i)
            {
                if (!SpawnEnemyShip)
                    break;

                Instantiate(enemyShip, new Vector3(10.0f, Random.Range(-4.2f, 4.2f), 0f), Quaternion.identity);
                yield return new WaitForSeconds(0.100f);
            }

            yield return new WaitForSeconds(1.5f);
        }
    }

    IEnumerator PowerupSpawn()
    {
        while (SpawnPowerupIcons)
        {
            int randomPowerup = Random.Range(0, 4);
            if (randomPowerup == 4)
            {
                randomPowerup = 3;
            }
            Instantiate(powerupIcons[randomPowerup], new Vector3(10, Random.Range(-4.2f, 4.2f), 0), Quaternion.identity);
            yield return new WaitForSeconds(10.0f);
        }
    }
}
