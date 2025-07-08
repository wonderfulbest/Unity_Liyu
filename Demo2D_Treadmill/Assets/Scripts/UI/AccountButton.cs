using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
using UnityEngine.UI;
public class AccountButton : MonoBehaviour
{
    public GameObject accountPanel;
    public Text text;
    void Start()
    {
        accountPanel.SetActive(false);
        // 设置按钮文本
        text = GetComponentInChildren<Text>();
    }


    void Update()
    {
        setPlayName();
    }
    public void OnAccountButtonClick()
    {
        accountPanel.SetActive(!accountPanel.activeSelf);
    }
    public void setPlayName()
    {
        // 获取玩家数据
        GameData gameData = SaveSystem.LoadDataGameData(); // 加载游戏数据
        // 设置文本为玩家名字
        text.text = gameData.GetPlayerData(gameData.currentPlayerName).playerName;

    }
}
