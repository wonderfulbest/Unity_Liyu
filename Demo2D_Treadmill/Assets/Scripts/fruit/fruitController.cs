using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释

public class fruitController : MonoBehaviour
{
    public GameObject[] fruitPrefab;
    public Vector2 minspawnAreaSize;
    public Vector2 maxspawnAreaSize;
    private float timer = 0f; // 计时器
    void Start()
    {

    }


    void Update()
    {
        timer += Time.deltaTime; // 增加计时器
        if (timer > 100f)
        {
            timer = 0f; // 重置计时器
            GameData gameData = SaveSystem.LoadDataGameData(); // 加载游戏数据
            if (gameData.currentPattren == "模式1")
            {
                CreateFruit_1(); // 创建水果
            }
            else if (gameData.currentPattren == "模式2")
            {
                CreateFruit_2(); // 创建水果
            }


        }
    }
    void CreateFruit_1()
    {
        int fruitIndex = Random.Range(0, fruitPrefab.Length); // 随机选择一个水果预制件
        Vector2 spawnPosition =
                    new Vector2(
                        Random.Range(minspawnAreaSize.x, maxspawnAreaSize.x),
                        Random.Range(minspawnAreaSize.y, maxspawnAreaSize.y)
                    );
        Instantiate(fruitPrefab[fruitIndex], spawnPosition, Quaternion.identity); // 实例化预制件
    }
    void CreateFruit_2()
    {
        int fruitIndex = Random.Range(0, fruitPrefab.Length); // 随机选择一个水果预制件
        Vector2 spawnPosition = new Vector2(6f, -1.38f);
        Instantiate(fruitPrefab[fruitIndex], spawnPosition, Quaternion.identity); // 实例化预制件
    }
}

