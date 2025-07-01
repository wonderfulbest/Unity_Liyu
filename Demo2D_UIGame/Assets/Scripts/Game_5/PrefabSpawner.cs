using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释

public class PrefabSpawner : MonoBehaviour
{
    public GameObject[] prefabs; // 预制体数组
    public float spawnRate = 2f; // 生成频率,越高越频繁
    public Vector2 spawnAreaMin; // 生成区域最小点
    public Vector2 spawnAreaMax; // 生成区域最大点
    public int maxSpawnCount = 10; // 最大生成数量
    private float nextSpawnTime = 0f;
    private int currentSpawnCount = 0;
    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnRandomPrefab();
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }

    void SpawnRandomPrefab()
    {
        // 随机选择预制体
        int randomIndex = Random.Range(0, prefabs.Length);
        GameObject prefabToSpawn = prefabs[randomIndex];

        // 随机位置
        float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Vector2 spawnPosition = new Vector2(randomX, randomY);

        // 实例化预制体
        if (currentSpawnCount < maxSpawnCount)
        {
            currentSpawnCount++;
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }
        else if (currentSpawnCount >= maxSpawnCount)
        {
            {
                Debug.Log("已达到最大生成数量: " + maxSpawnCount);
                return;
            }
        }
    }
}