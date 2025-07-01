using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI; // 引入UI命名空间
//注释
public class LandMarkButton : MonoBehaviour
{
    public static LandMarkButton Instance; // 单例模式
    public string landmarkName; // 地标名称
    public GameObject landmarkPrefab; // 地标预制件
    public bool isButtonOn = false;
    void Start()
    {
        Instance = this; // 初始化单例
        landmarkPrefab.SetActive(false); // 初始时隐藏地标预制件
        isButtonOn = false; // 初始状态为关闭


    }


    void Update()
    {

    }
    public void OnButtonClicked()
    {
        // 处理按钮点击事件
        Debug.Log("Clicked on landmark: " + landmarkName);
        if (landmarkPrefab != null)
        {
            isButtonOn = !isButtonOn; // 切换按钮状态
            landmarkPrefab.SetActive(isButtonOn);




        }
    }

}