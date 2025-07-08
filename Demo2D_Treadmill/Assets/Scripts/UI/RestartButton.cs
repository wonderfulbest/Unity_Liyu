using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
using UnityEngine.SceneManagement; // 引入场景管理命名空间
public class RestartButton : MonoBehaviour
{
    void Start()
    {

    }


    void Update()
    {

    }
    public void OnRestartButtonClick()
    {
        // 重新加载当前场景
        Player_information.instance.SaveScore(Player_information.instance.playerScore); // 保存玩家得分
        Player_information.instance.SaveBeijingTime(); // 保存北京时间
        Time.timeScale = 1f; // 恢复游戏时间
        SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

    }
}
