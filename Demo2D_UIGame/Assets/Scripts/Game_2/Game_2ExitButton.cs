using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//注释
public class Game_2ExitButton : MonoBehaviour
{
    private GameObject childObj;
    void Start()
    {
        childObj = transform.GetChild(0).gameObject; // 获取子物体
        childObj.SetActive(false); // 设置子物体不显示
    }


    void Update()
    {

    }
    public void OnExitButtonPressed()
    {
        childObj.SetActive(true);
        Invoke("changeScene", 1f); // 延迟1秒后调用changeScene方法
    }

    void changeScene()
    {
        SceneManager.LoadScene(0);
    }
}
