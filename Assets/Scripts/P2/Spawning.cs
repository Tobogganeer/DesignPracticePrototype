using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform[] spawnPoints;

    public Vector2 spawnDelay = new Vector2(0.5f, 2f);
    float timer;

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = Random.Range(spawnDelay.x, spawnDelay.y);
            GameObject enemy = prefabs[Random.Range(0, prefabs.Length)];
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemy, spawnPoint.position, Quaternion.identity);
        }
    }
}
