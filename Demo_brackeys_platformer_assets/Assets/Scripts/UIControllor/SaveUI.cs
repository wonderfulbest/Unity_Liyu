using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveUI : MonoBehaviour
{
    public GameObject savePanel; // 保存面板的引用
    private bool isPanelActive = false; // 保存面板是否激活的状态
    void Start()
    {
        isPanelActive = false; // 初始化保存面板为不激活状态
        savePanel.SetActive(false); // 确保保存面板在开始时是隐藏的
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPanelActive)
        {
            isPanelActive = true;
            savePanel.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPanelActive)
        {
            isPanelActive = false;
            savePanel.SetActive(false);
        }
    }
}
