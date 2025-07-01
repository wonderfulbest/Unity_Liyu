using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
using UnityEngine.SceneManagement; // 需要引入场景管理命名空间

public class RestartButton : MonoBehaviour
{
    // 绑定到重新开始按钮的点击事件
    public void RestartCurrentScene()
    {
        // 恢复时间流速（如果之前暂停了）
        Time.timeScale = 1f;

        // 获取当前场景名称并重新加载
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
