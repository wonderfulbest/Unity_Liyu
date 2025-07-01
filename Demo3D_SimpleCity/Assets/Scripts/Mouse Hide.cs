using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;
//注释

public class MouseHide : MonoBehaviour
{
    GameObject[] FindGameObjectsInLayer(int layer)
    {
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        return System.Array.FindAll(allObjects, obj => obj.layer == layer);
    }
    public bool hideMouse;
    public GameObject ob;
    void Start()
    {
        HideMouse();
        int uiLayer = LayerMask.NameToLayer("UI"); // 获取 "UI" 层的索引
        GameObject[] uiObjects = FindGameObjectsInLayer(uiLayer); // 获取UI对象
    }

    void Update()
    {
        // 检测摄像机状态变化
        if (CameraChanger.Instance.MainCamera.gameObject.activeSelf)
        {
            HideMouse();
            DisableUIClicks(); // 禁用UI交互
        }
        else if (hideMouse)
        {
            ShowMouse();
            EnableUIClicks(); // 启用UI交互
        }
    }

    void HideMouse()
    {
        hideMouse = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;// 锁定鼠标到屏幕中心
    }

    void ShowMouse()
    {
        hideMouse = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void DisableUIClicks()
    {
        // 禁用所有按钮
        Button[] allButtons = FindObjectsOfType<Button>();
        foreach (Button btn in allButtons)
        {
            btn.interactable = false;
        }

        // 禁用所有输入框等
        Selectable[] allSelectables = FindObjectsOfType<Selectable>();
        foreach (Selectable selectable in allSelectables)
        {
            selectable.interactable = false;
        }
    }
    void EnableUIClicks()
    {
        // 启用所有按钮
        Button[] allButtons = FindObjectsOfType<Button>();
        foreach (Button btn in allButtons)
        {
            btn.interactable = true;
        }
        // 启用所有输入框等
        Selectable[] allSelectables = FindObjectsOfType<Selectable>();
        foreach (Selectable selectable in allSelectables)
        {
            selectable.interactable = true;
        }
    }
}