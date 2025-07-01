using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//注释
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    public GameObject confirmationPanel;
    public Button yesButton;
    public Button noButton;

    void Start()
    {
        // 初始隐藏确认面板
        confirmationPanel.SetActive(false);

        // 为确认按钮添加事件
        yesButton.onClick.AddListener(ConfirmExit);
        noButton.onClick.AddListener(CancelExit);
    }

    public void OnExitButtonClick()
    {
        // 显示确认对话框
        confirmationPanel.SetActive(true);
    }

    void ConfirmExit()
    {
        ExitGame();
    }

    void CancelExit()
    {
        confirmationPanel.SetActive(false);
    }

    void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
}