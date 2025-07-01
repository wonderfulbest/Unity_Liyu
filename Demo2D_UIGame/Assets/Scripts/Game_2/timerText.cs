using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//注释
public class timerText : MonoBehaviour
{
    private Text timertext;
    float timer = 5.1f; // 计时器
    void Start()
    {
        timertext = GetComponent<Text>(); // 获取Text组件
    }


    void Update()
    {
        timer -= Time.deltaTime; // 增加计时器
        timertext.text = timer + "s"; // 更新文本显示
        if (timer <= 0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
