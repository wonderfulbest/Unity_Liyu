using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class Player_information : MonoBehaviour
{
    public static Player_information instance;
    public float playerScore = 0; // 玩家得分
    public float playerSpeed = 0; // 玩家速度
    public int playerPattern = 0; // 玩家模式
    public string playerName; // 玩家名字
    public string time; // 玩家时间

    public GameObject player; // 玩家对象
    void Start()
    {
        instance = this; // 确保实例化
        playerScore = 0;
        playerSpeed = 0.5f; // 初始速度设置为0.5
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.D)) // 检测D键按下
        {
            if (playerPattern == 0)
            {
                playerSpeed = 0.5f; // 按下D键时，设置玩家速度为0.5
            }
            else if (playerPattern == 1)
            {
                playerSpeed += 0.1f * Time.deltaTime; // 在变速模式下，速度逐渐增加
            }
        }

    }
    public void AddScore(float score)
    {
        playerScore += score; // 增加得分
    }
    public void LessenScore(float score)
    {
        playerScore -= score;
    }
    public void SaveName(string name)
    {
        GameData gameData = SaveSystem.LoadDataGameData(); // 加载游戏数据
        gameData.currentPlayerName = name; // 设置当前玩家名字
        gameData.GetPlayerData(name); // 获取或创建玩家数据
        SaveSystem.SaveData(gameData); // 保存玩家数据
    }
    public void SavePattern(int x)
    {
        GameData gameData = SaveSystem.LoadDataGameData(); // 加载游戏数据
        gameData.currentPattren = "模式" + x;
        SaveSystem.SaveData(gameData); // 保存游戏数据
    }
    public void SaveScore(float score)
    {
        GameData gameData = SaveSystem.LoadDataGameData(); // 加载游戏数据
        gameData.GetPlayerData(gameData.currentPlayerName).AddScore(score); // 将当前得分添加到玩家数据中
        SaveSystem.SaveData(gameData); // 保存玩家数据
    }
    public void SaveBeijingTime()
    {
        GameData gameData = SaveSystem.LoadDataGameData();
        DateTime beijingTime = GetBeijingTime();// 获取当前北京时间
        gameData.GetPlayerData(gameData.currentPlayerName).beijingTime = beijingTime.ToString("yyyy-MM-dd HH:mm:ss");
        SaveSystem.SaveData(gameData);
        //gameData.GetPlayerData(gameData.currentPlayerName).timestamp = ((DateTimeOffset)beijingTime).ToUnixTimeSeconds();
    }
    public DateTime GetBeijingTime()
    {
        // 获取当前UTC时间
        DateTime utcNow = DateTime.UtcNow;
        // 转换为北京时间 (UTC+8)
        DateTime beijingTime = utcNow.AddHours(8);
        return beijingTime;
    }
}
