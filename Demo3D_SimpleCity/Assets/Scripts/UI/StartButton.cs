using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        // 加载游戏场景（替换"GameScene"为你的游戏场景名称）
        SceneManager.LoadScene(1);
    }
}