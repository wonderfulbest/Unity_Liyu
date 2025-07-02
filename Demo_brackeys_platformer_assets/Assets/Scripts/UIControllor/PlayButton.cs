using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
//注释
public class PlayButton : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {

    }

    public void OnPlayButton()
    {
        SceneManager.LoadScene("Game_1"); // 加载第一个游戏场景
    }
}
