using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public ItemConfig itemConfig;
    [Range(0f, 1f)] public float coinSpawnChance = 0.6f;
    [Range(0f, 1f)] public float enemySpawnChance = 0.4f;

    private Queue<GameObject> coinPool = new Queue<GameObject>();
    private Dictionary<EnemyType, Queue<Enemy>> enemyPools = new Dictionary<EnemyType, Queue<Enemy>>();

    void Start()
    {
        InitializePools();
        SpawnObjects();
    }

    void InitializePools()
    {
        for (int i = 0; i < 15; i++)
        {
            GameObject coin = Instantiate(itemConfig.CoinConfig.coinPrefab);
            coin.SetActive(false);
            coinPool.Enqueue(coin);
        }

        foreach (var enemyConfig in itemConfig.EnemyConfig)
        {
            if (!enemyPools.ContainsKey(enemyConfig.EnemyType))
            {
                enemyPools[enemyConfig.EnemyType] = new Queue<Enemy>();
            }

            for (int i = 0; i < 5; i++)
            {
                Enemy enemy = Instantiate(enemyConfig.EnemyPrefab);
                enemy.gameObject.SetActive(false);
                enemyPools[enemyConfig.EnemyType].Enqueue(enemy);
            }
        }
    }

    void SpawnObjects()
    {
        Platform[] platforms = itemConfig.PlatformConfig.OrderBy(x => Random.value).ToArray();
        foreach (Platform platform in platforms)
        {
            float roll = Random.Range(0f, 1f);

            if (roll <= enemySpawnChance && platform.EnemyPoint != null)
            {
                EnemyType[] enemyTypes = enemyPools.Keys.ToArray();
                EnemyType selectedType = enemyTypes[Random.Range(0, enemyTypes.Length)];

                if (enemyPools[selectedType].Count > 0)
                {
                    Enemy enemy = enemyPools[selectedType].Dequeue();
                    enemy.transform.position = platform.EnemyPoint.position;
                    enemy.gameObject.SetActive(true);
                }
            }
            else if (roll <= enemySpawnChance + coinSpawnChance && coinPool.Count > 0)
            {
                int coinGroupSize = Random.Range(1, 7);
                Vector3[] offsets = new Vector3[]
                {
                    Vector3.zero,
                    Vector3.left * 0.6f,
                    Vector3.right * 0.6f,
                    Vector3.up * 0.6f,
                    (Vector3.left + Vector3.up) * 0.6f,
                    (Vector3.right + Vector3.up) * 0.6f
                };

                for (int i = 0; i < coinGroupSize && coinPool.Count > 0; i++)
                {
                    GameObject coin = coinPool.Dequeue();
                    coin.transform.position = platform.CoinPoint.position + offsets[Random.Range(0, offsets.Length)];
                    coin.SetActive(true);
                    Coin coinScript = coin.GetComponent<Coin>();
                    if (coinScript != null)
                    {
                        coinScript.value = itemConfig.CoinConfig.value;
                    }
                }
            }
        }
    }
}