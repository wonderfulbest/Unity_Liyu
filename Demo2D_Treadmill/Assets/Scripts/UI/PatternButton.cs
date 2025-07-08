using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
using UnityEngine.UI; // 引入UI命名空间以使用Text组件
public class PatternButton : MonoBehaviour
{
    public static PatternButton instance; // 单例实例，用于访问模式按钮
    Text text; // UI文本组件，用于显示按钮的名称
    private int patternIndex; // 模式索引，用于区分不同的模式
    private string[] patternNames = { "模式1", "模式2" }; // 模式名称列表
    void Start()
    {
        instance = this; // 设置单例实例
        text = GetComponentInChildren<Text>(); // 获取当前按钮下的Text组件
    }


    void Update()
    {
        PatternState();
    }
    public void OnPatternButtonClick() // 点击按钮时调用
    {
        patternIndex = (patternIndex + 1) % patternNames.Length;
    }

    void PatternState()
    {
        switch (patternIndex)
        {
            case 0:
                text.text = "模式1";
                Pattern_0();
                break;
            case 1:
                text.text = "模式2";
                Pattern_1();
                break;

        }
    }
    void Pattern_0()
    {
        Player_information.instance.playerPattern = 1; // 设置玩家模式为匀速模式
    }
    void Pattern_1()
    {
        Player_information.instance.playerPattern = 2;// 设置玩家模式为变速模式
    }
}
