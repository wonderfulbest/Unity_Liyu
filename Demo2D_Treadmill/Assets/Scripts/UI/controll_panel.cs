using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class controll_panel : MonoBehaviour
{
    public GameObject player; // 玩家对象
    public GameObject game_panel; // 控制面板对象
    public GameObject setting_panel;
    public GameObject remainderText;
    //private bool issetting_Panel = false;
    void Start()
    {
        game_panel.SetActive(false); // 初始时隐藏控制面板
        setting_panel.SetActive(false); // 初始时隐藏设置面板
        remainderText.SetActive(true);
        //issetting_Panel = false;
    }


    void Update()
    {
        if (player.transform.position.y < -10f)
        {
            // 如果玩家掉出屏幕，重置玩家位置
            player.transform.position = new Vector3(-0.03f, -1.18f, 0f); // 重置玩家位置
            game_panel.SetActive(true); // 显示控制面板
            Time.timeScale = 0f; // 暂停游戏时间
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            remainderText.SetActive(false);
        }
        //if (Input.GetKeyUp(KeyCode.Escape))
        //{
        //    issetting_Panel = !issetting_Panel; // 切换控制面板状态
        //    setting_panel.SetActive(issetting_Panel); // 显示控制面板
        //    if (issetting_Panel == true)
        //    {
        //        // 如果控制面板被打开，暂停游戏时间
        //        Time.timeScale = 0f;
        //    }
        //    else if (issetting_Panel == false)
        //    {
        //        // 如果控制面板被关闭，恢复游戏时间
        //        Time.timeScale = 1f;
        //    }

        //}
    }
}
