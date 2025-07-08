using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//注释
public class timeText : MonoBehaviour
{
    private Text timeDisplay;
    void Start()
    {
        timeDisplay = GetComponent<Text>();
    }


    void Update()
    {
        GameData gameData = SaveSystem.LoadDataGameData();
        timeDisplay.text = "最后一次游玩时间: " + gameData.GetPlayerData(gameData.currentPlayerName).beijingTime;
    }
}
