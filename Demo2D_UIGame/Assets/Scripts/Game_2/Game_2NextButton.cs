using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
//注释
public class Game_2NextButton : MonoBehaviour
{
    int currentSceneIndex;
    private GameObject childObj;
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        childObj = transform.GetChild(0).gameObject; // 获取子物体
        childObj.SetActive(false); // 设置子物体不显示
    }


    void Update()
    {

    }
    public void OnNextButtonClick()
    {

        // 在加载新场景之前，先显示子物体
        childObj.SetActive(true);
        Invoke("changeScene", 1f); // 延迟1秒后调用changeScene方法
    }
    void changeScene()
    {
        currentSceneIndex++;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
