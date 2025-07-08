using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
using System.IO;
using System;

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public List<float> scores = new List<float>();
    public string beijingTime;// 用于存储北京时间字符串
    public long timestamp;// 用于存储时间戳

    // 添加新分数
    public void AddScore(float score)
    {
        scores.Add(score);
        // 可以在这里添加排序逻辑，如果需要保持分数有序
    }
}

[System.Serializable]
public class GameData
{
    public List<PlayerData> allPlayers = new List<PlayerData>();
    public string currentPlayerName;
    public string currentPattren; // 当前模式
    // 获取或创建玩家数据
    // 通过玩家名字获取玩家数据，如果不存在则创建新的
    public PlayerData GetPlayerData(string playerName)
    {
        foreach (var player in allPlayers)
        {
            if (player.playerName == playerName)
                return player;
        }
        // 如果没找到，创建新玩家数据
        var newPlayer = new PlayerData();
        newPlayer.playerName = playerName;
        allPlayers.Add(newPlayer);
        return newPlayer;
    }
}
public static class SaveSystem
{
    private static string savePath => Application.persistentDataPath + "/playerData.json";
    //Application.persistentDataPath在Windows上通常是C:\Users\用户名\AppData\LocalLow\公司名\项目名


    public static void SaveData(GameData data)
    {
        string jsonData = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, jsonData);
        Debug.Log("数据已保存到: " + savePath);
    }

    public static GameData LoadDataGameData()
    {
        if (File.Exists(savePath))
        {
            string jsonData = File.ReadAllText(savePath);
            return JsonUtility.FromJson<GameData>(jsonData);
        }
        else
        {
            Debug.Log("未找到存档文件，创建新存档");
            return new GameData();
        }
    }
}
public class DataManager : MonoBehaviour
{
    private GameData gameData;

    private void Start()
    {
        // 加载现有数据
        gameData = SaveSystem.LoadDataGameData();
    }

    //显示所有分数
    //public void DisplayAllScores()
    //{
    //    foreach (float score in playerData.scores)
    //    {
    //        Debug.Log(playerData.playerName + "的分数: " + score);
    //    }
    //}




}