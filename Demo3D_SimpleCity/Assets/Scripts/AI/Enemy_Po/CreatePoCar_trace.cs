using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class CreatePoCar_trace : MonoBehaviour
{
    public static CreatePoCar_trace Instance;
    public GameObject enemyPrefab;
    void Start()
    {
        Instance = this;
        enemyPrefab.SetActive(false);
    }


    void Update()
    {

    }
    public void SpawnEnemy()
    {
        enemyPrefab.SetActive(true);
    }
    public void OnSpawnEnemy()
    {
        Invoke("SpawnEnemy", 2f);
    }
}
