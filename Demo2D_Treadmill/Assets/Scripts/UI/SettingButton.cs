using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class SettingButton : MonoBehaviour
{
    public GameObject settingPanel; // 设置面板对象
    void Start()
    {
        settingPanel.SetActive(false); // 初始时隐藏设置面板
    }


    void Update()
    {

    }

    public void OnSettingButtonClick() // 点击设置按钮时调用
    {
        if (settingPanel.activeSelf) // 如果设置面板当前是显示状态
        {
            settingPanel.SetActive(false); // 隐藏设置面板
        }
        else // 如果设置面板当前是隐藏状态
        {
            settingPanel.SetActive(true); // 显示设置面板
        }
    }
}
