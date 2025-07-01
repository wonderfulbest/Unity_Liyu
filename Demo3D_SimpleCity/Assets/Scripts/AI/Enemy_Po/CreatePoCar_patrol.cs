using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class CreatePoCar_patrol : MonoBehaviour
{
    public static CreatePoCar_patrol Instance;
    public GameObject enemyPrefab;
    public float spawnRadius = 10f;// 敌人生成半径

    void Start()
    {
        Instance = this;
    }
    private void Update()
    {


    }
    // 在指定位置生成敌人
    public void SpawnEnemy()
    {
        Vector3 randomPosition = transform.position + Random.insideUnitSphere * spawnRadius;
        randomPosition.y = 0; // 保持在地面上
        Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

    }
    public void OnSpawnEnemy()
    {
        Invoke("SpawnEnemy", 2f);
    }
}