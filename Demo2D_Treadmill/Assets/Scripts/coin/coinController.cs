using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class coinController : MonoBehaviour
{
    public static coinController instance; // 单例模式
    public Vector2 minspawnAreaSize;
    public Vector2 maxspawnAreaSize;
    public GameObject coinPrefab; // 硬币预制件
    private float timer = 0f; // 计时器
    void Start()
    {
        instance = this; // 初始化单例实例
    }


    void Update()
    {
        timer += Time.deltaTime; // 增加计时器
        if (timer > 8f)
        {
            timer = 0f; // 重置计时器
            GameData gameData = SaveSystem.LoadDataGameData(); // 加载游戏数据
            if (gameData.currentPattren == "模式1")
            {
                CreateCoin_1(); // 创建硬币
            }
            else if (gameData.currentPattren == "模式2")
            {
                CreateCoin_2(); // 创建硬币
            }


        }
    }

    void CreateCoin_1()
    {

        Vector2 spawnPosition =
                    new Vector2(
                        Random.Range(minspawnAreaSize.x, maxspawnAreaSize.x),
                        Random.Range(minspawnAreaSize.y, maxspawnAreaSize.y)
                    );
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity); // 实例化预制件

    }
    void CreateCoin_2()
    {

        Vector2 spawnPosition = new Vector2(6f, -1.38f);
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity); // 实例化预制件

    }
    //下金币雨
    public void CreateCoinRain()
    {

        for (int i = 0; i < 1000; i++)
        {
            Invoke("CreateCoin_1", 0.1f);


        }
    }

}
