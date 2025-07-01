using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//注释
public class remainderText : MonoBehaviour
{
    public static remainderText instance; // 单例模式实例引用
    private Text text; // 文本组件引用
    public string textContent; // 默认文本内容
    void Start()
    {
        instance = this; // 设置单例实例
        text = GetComponent<Text>(); // 获取文本组件
        text.text = textContent; // 设置默认文本内容
    }


    void Update()
    {
        if (InputFieldHandler.instance.isInputCorrect)
        {
            text.text = "输入正确！"; // 输入正确时显示的文本
        }
        else
        {
            text.text = "输入错误"; // 输入错误时显示的文本
        }
    }
}
