using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class BackButton : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {

    }
    public void OnBackButtonClick()
    {

        Player_information.instance.SaveScore(Player_information.instance.playerScore); // 保存玩家得分
        Player_information.instance.SaveBeijingTime(); // 保存北京时间
        UnityEngine.SceneManagement.SceneManager.LoadScene("Start_0");// 返回到主菜单场景
    }
}
