using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class remainderImage : MonoBehaviour
{
    public GameObject exitButton;
    public GameObject nextButton;
    void Start()
    {
        exitButton.SetActive(false);
        nextButton.SetActive(false);
    }


    void Update()
    {
        if (InputFieldHandler.instance.isInputCorrect)
        {
            nextButton.SetActive(true); // 输入正确时显示下一步按钮
        }
        else if (!InputFieldHandler.instance.isInputCorrect)
        {
            exitButton.SetActive(true); // 输入错误时隐藏退出按钮
        }
    }
}
