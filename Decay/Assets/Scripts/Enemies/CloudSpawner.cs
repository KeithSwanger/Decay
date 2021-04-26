using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudSpawnPrefab;
    PlayerController player;


    float spawnTimer;
    float spawnTimerReset = 3f;
    private void Awake()
    {
        player = GameController.Instance.player;
        spawnTimer = spawnTimerReset;
    }

    private void Update()
    {
        if (spawnTimer <= 0f)
        {
            spawnTimer = spawnTimerReset;
            TrySpawn();
        }

        spawnTimer -= Time.deltaTime;
    }

    private void TrySpawn()
    {
        if (player.IsInvincible)
        {
            //Player is on a black screen, don't spawn
            return;
        }

        //if (Random.value < ((float)player.Stats.Depression * (float)player.Stats.Decay / 100f)) // The higher diseaese and decay are, the more likely they are to spawn
        //if (Random.value < (((float)player.Stats.Depression + (float)player.Stats.Decay) / 100)) // maximum of 18% chance to spawn every 2.5 seconds
        if (Random.value < ((((float)player.Stats.Depression * (float)player.Stats.Decay) * 0.75f) / 100)) // maximum of 18% chance to spawn every 2.5 seconds
        {
            Vector2 spawnLocation;
            spawnLocation.x = player.transform.position.x;
            spawnLocation.y = player.transform.position.y;
            Instantiate(cloudSpawnPrefab, spawnLocation, Quaternion.identity);
        }
    }
}
