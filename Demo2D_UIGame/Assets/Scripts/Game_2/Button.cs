using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class Button : MonoBehaviour
{
    private GameObject childObj;
    void Start()
    {
        childObj = transform.GetChild(0).gameObject; // 获取子物体
        childObj.SetActive(false); // 设置子物体不显示
    }

    public void OnButtonPressed()
    {
        childObj.SetActive(true);
    }

    void Update()
    {

    }
}
