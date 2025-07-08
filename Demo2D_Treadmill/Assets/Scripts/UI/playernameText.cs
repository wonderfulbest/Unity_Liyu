using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//注释
public class playernameText : MonoBehaviour
{
    private Text playerNameDisplay;
    void Start()
    {
        playerNameDisplay = GetComponent<Text>();
    }


    void Update()
    {
        GameData gameData = SaveSystem.LoadDataGameData();
        playerNameDisplay.text = "当前玩家: " + gameData.currentPlayerName;
    }
}
