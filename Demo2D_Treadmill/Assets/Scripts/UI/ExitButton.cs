using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class ExitButton : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {

    }
    public void OnExitButtonClick()
    {
        // 退出游戏
        Application.Quit();

        // 如果在编辑器中运行，可以使用以下代码来停止播放
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
