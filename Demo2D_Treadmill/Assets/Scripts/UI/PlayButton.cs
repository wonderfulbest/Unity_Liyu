using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//注释
public class PlayButton : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {

    }
    public void OnPlayButtonClick()
    {
        Time.timeScale = 1f; // 确保游戏时间正常流逝
        if (Player_information.instance.playerPattern == 1)
        {
            GameData gameData = SaveSystem.LoadDataGameData(); // 加载游戏数据
            gameData.currentPattren = "模式1"; // 设置当前模式为模式1
            SaveSystem.SaveData(gameData); // 保存游戏数据
            SceneManager.LoadScene("Game_1"); // 加载游戏场景
        }
        else if (Player_information.instance.playerPattern == 2)
        {
            GameData gameData = SaveSystem.LoadDataGameData(); // 加载游戏数据
            gameData.currentPattren = "模式2"; // 设置当前模式为模式1
            SaveSystem.SaveData(gameData); // 保存游戏数据
            SceneManager.LoadScene("Game_2"); // 加载游戏场景
        }
    }
}
