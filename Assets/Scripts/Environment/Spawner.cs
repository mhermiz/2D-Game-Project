using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnPattern;
    public GameObject player;

    private float enemyPhaseDuration;
    private float collectiblePhaseDuration;
    public static float phasetimer = 0f;
    private float nextEnemySpawnTime;
    private float nextCollectibleSpawnTime;
    public static bool enemyPhase = false;
    public static float timer = 0f;

    public static List<GameObject> spawnedObjects = new(); // Track spawns

    // Start is called before the first frame update
    void Start()
    {
        // Pick first spawn randomly
        nextEnemySpawnTime = Random.Range(1f, 5f);
        nextCollectibleSpawnTime = Random.Range(1f, 2f);

        // Phase interval
        enemyPhaseDuration = Random.Range(10f, 20f);
        collectiblePhaseDuration = Random.Range(3f, 7f);
    }

    // Update is called once per frame
    void Update()
    {
        phasetimer += Time.deltaTime;

        if (enemyPhase && phasetimer >= enemyPhaseDuration)
        {
            enemyPhase = false;
            phasetimer = 0f;
        }
        else if (!enemyPhase && phasetimer >= collectiblePhaseDuration)
        {
            enemyPhase = true;
            phasetimer = 0f;
        }

        if (enemyPhase)
        {
            HandleEnemySpawning();
        }
        else
        {
            HandleCollectibleSpawning();
        }
    }

    void HandleEnemySpawning()
    {
        timer += Time.deltaTime;
        if (timer >= nextEnemySpawnTime)
        {
            SpawnShadowHand();
            timer = 0f;
            nextEnemySpawnTime = Random.Range(1f, 5f);
        }
    }

    void HandleCollectibleSpawning()
    {
        timer += Time.deltaTime;
        if (timer >= nextCollectibleSpawnTime)
        {
            if (Collectible.soulcounter >= 15 && Random.value < 0.35f)
            {
                SpawnShadowHand();
            }

            SpawnSoulOrb();
            timer = 0f;
            nextCollectibleSpawnTime = Random.Range(1f, 2f);
        }
    }

    void SpawnShadowHand()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, player.transform.position.y);
        GameObject shadowhand = Instantiate(spawnPattern[0], spawnPos, Quaternion.identity);

        // Pass the player reference to the ShadowHand script
        shadowhand.GetComponent<ShadowHand>().player = player;

        // Keep track of spawned objects
        spawnedObjects.Add(shadowhand);
    }

    void SpawnSoulOrb()
    {
        // Random y spawn
        float randomY = Random.Range(-3.5f, 3.5f);

        // Random collectible pattern
        int collectPattern = Random.Range(1, 3);

        Vector3 spawnPos = new Vector3(transform.position.x, randomY);
        GameObject soulOrb = Instantiate(spawnPattern[collectPattern], spawnPos, Quaternion.identity);

        // Keep track of spawned objects
        spawnedObjects.Add(soulOrb);
    }

    public static void ClearSpawns()
    {
        foreach (GameObject obj in spawnedObjects)
        {
            if (obj != null)
                Destroy(obj);
        }
        spawnedObjects.Clear();
    }

    public static void ResetSpawner()
    {
        enemyPhase = false;
        phasetimer = 0f;
        timer = 0f;
    }
}
