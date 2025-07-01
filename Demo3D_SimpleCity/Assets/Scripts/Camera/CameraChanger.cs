using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class CameraChanger : MonoBehaviour
{
    public static CameraChanger Instance { get; private set; } // 单例模式
    public Camera MainCamera;//主摄像机
    public Camera MaxMapCamera;//大地图摄像机

    public bool isMaxMapActive = false; // 是否处于大地图模式
    void Start()
    {
        Instance = this;
        // 确保至少有一个摄像机
        if (MainCamera == null || MaxMapCamera == null)
        {
            Debug.LogError("没有分配摄像机！");
            enabled = false;
            return;
        }
        isMaxMapActive = false; // 初始化为非大地图模式

        // 激活默认摄像机
        MainCamera.gameObject.SetActive(true);
        MaxMapCamera.gameObject.SetActive(false);

    }

    void Update()
    {
        if (!MenuPanel.instance.isMenu)
        {
            //按下M键，先重制摄像机，然后再关闭
            if (Input.GetKeyDown(KeyCode.M) && !isMaxMapActive)
            {
                SwitchCamera();
            }
            else if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.M)) && isMaxMapActive)
            {
                Invoke("SwitchCamera", 0.1f);
            }
        }
        else if (MenuPanel.instance.isMenu)
        {
            return;
        }
    }

    public void SwitchCamera()
    {
        isMaxMapActive = !isMaxMapActive; // 切换大地图状态
        MainCamera.gameObject.SetActive(!isMaxMapActive);
        MaxMapCamera.gameObject.SetActive(isMaxMapActive);
    }


}