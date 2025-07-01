using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
using UnityEngine.UI;

public class InputFieldHandler : MonoBehaviour
{
    public static InputFieldHandler instance; // 单例模式实例引用
    private InputField inputField; // 输入框引用
    public GameObject hintImage; // 提示图片
    // 预期的正确输入
    private string correctInput = "7"; // 替换为你需要的正确值
    public bool isInputCorrect; // 输入是否正确的标志
    void Start()
    {
        instance = this; // 设置单例实例
        inputField = GetComponent<InputField>(); // 获取输入框组件
        hintImage.SetActive(false); // 显示提示图片
    }
    private void Update()
    {

    }

    public void OnConfirmButtonPressed()
    {
        hintImage.SetActive(true); // 显示提示图片
        if (inputField.text == correctInput)
        {
            // 输入正确，执行相应操作
            isInputCorrect = true; // 设置输入正确标志
        }
        else
        {
            // 输入错误，显示提示文本
            isInputCorrect = false; // 设置输入错误标志
        }
    }
}