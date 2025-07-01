using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class SpawnRandom : MonoBehaviour
{
    public Vector2 spawnAreaMin; // 生成区域最小点
    public Vector2 spawnAreaMax; // 生成区域最大点
    public GameObject[] prefabs; // 预制体数组
    void Start()
    {
        for (int i = 0; i < prefabs.Length; i++)
        {
            SpawnRandomPrefab(prefabs[i]);
        }

    }


    void Update()
    {

    }
    void SpawnRandomPrefab(GameObject prefab)
    {
        // 随机位置
        float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Vector2 spawnPosition = new Vector2(randomX, randomY);
        prefab.transform.position = spawnPosition;


    }
}
