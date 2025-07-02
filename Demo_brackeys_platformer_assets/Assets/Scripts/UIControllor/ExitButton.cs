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

    public void OnExitButton()
    {
        // 在编辑器中停止播放
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // 在构建的游戏中退出应用
            Application.Quit();
#endif
    }
}
