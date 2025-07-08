using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//注释
public class PatternText : MonoBehaviour
{
    private Text patternText; // 用于显示模式的文本组件
    void Start()
    {
        patternText = GetComponent<Text>(); // 获取当前GameObject上的Text组件
    }


    void Update()
    {
        GameData gameData = SaveSystem.LoadDataGameData(); // 加载游戏数据

        patternText.text = gameData.currentPattren; // 更新文本为当前模式
    }
}
