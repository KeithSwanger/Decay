using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseaseSpawner : MonoBehaviour
{
    public GameObject diseaseSpawnPrefab;
    PlayerController player;


    float spawnTimer;
    float spawnTimerReset = 4f;
    private void Awake()
    {
        player = GameController.Instance.player;
        spawnTimer = spawnTimerReset;
    }

    private void Update()
    {
        if(spawnTimer <= 0f)
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

        int enemiesToSpawn = Mathf.FloorToInt(player.Stats.Disease * player.Stats.Decay);
        //int enemiesToSpawn = 80;

        //if(Random.value < ((float)player.Stats.Disease * (float)player.Stats.Decay / 100f)) // The higher diseaese and decay are, the more likely they are to spawn
        if (true) // The higher diseaese and decay are, the more likely they are to spawn
            {
            for(int i = 0; i < enemiesToSpawn; i++)
            {
                Vector2 spawnLocation;
                spawnLocation.x = player.transform.position.x + Random.Range(-32f, 32f);
                spawnLocation.y = player.transform.position.y + Random.Range(-25f, 25f);
                Instantiate(diseaseSpawnPrefab, spawnLocation, Quaternion.identity);
            }
        }
    }
}
