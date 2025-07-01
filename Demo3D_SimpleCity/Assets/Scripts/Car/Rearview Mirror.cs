using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class RearviewMirror : MonoBehaviour
{
    public static RearviewMirror instance;
    public GameObject RearviewImage;
    public GameObject MinimapImage;
    void Start()
    {
        instance = this; // 设置单例实例
        RearviewImage.SetActive(false); // 初始时隐藏后视镜图像
        MinimapImage.SetActive(true);
    }


    void Update()
    {
        SwitchToSecondPersonView();
    }

    //倒车切换第二人称视角
    public void SwitchToSecondPersonView()
    {
        WheelCollider[] wheels = CarController.instance.wheelColliders;
        float totalRPM = 0;

        foreach (var wheel in wheels)
        {
            totalRPM += wheel.rpm;
        }


        if (totalRPM < -10 && Input.GetKey(KeyCode.S))
        {
            // 倒车
            RearviewImage.SetActive(true);
            MinimapImage.SetActive(false); // 隐藏小地图图像
        }
        else if (totalRPM >= 10 && Input.GetKey(KeyCode.W))
        {
            // 前进或停止时切换回第三人称视角
            RearviewImage.SetActive(false);
            MinimapImage.SetActive(true);
        }
    }
}
