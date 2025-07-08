using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//注释
public class ScoreText : MonoBehaviour
{
    public static ScoreText instance;
    private Text scoreText;
    void Start()
    {
        instance = this; // 确保实例化
        scoreText = GetComponent<Text>();

    }


    void Update()
    {
        scoreText.text = "得分: " + Player_information.instance.playerScore.ToString(); // 初始化得分文本
    }
}
