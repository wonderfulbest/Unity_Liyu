using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//注释
public class ExitButton : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {

    }
    public void OnExitButtonPressed()
    {
        // 重新加载当前场景（会重置所有对象）
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // 或者加载开始菜单场景（如果有单独的开始场景）
        SceneManager.LoadScene(0);
    }
}
