using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    public GameObject confirmationPanel;
    public Button yesButton;
    public Button noButton;

    void Start()
    {
        // 初始隐藏确认面板
        confirmationPanel.SetActive(false);

        // 为确认按钮添加事件
        yesButton.onClick.AddListener(ConfirmQuit);
        noButton.onClick.AddListener(CancelQuit);
    }

    public void OnQuitButtonClick()
    {
        // 显示确认对话框
        confirmationPanel.SetActive(true);
    }

    void ConfirmQuit()
    {
        QuitGame();
    }

    void CancelQuit()
    {
        confirmationPanel.SetActive(false);
    }

    void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}