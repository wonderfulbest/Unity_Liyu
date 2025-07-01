using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class ButtonMove : MonoBehaviour
{
    public GameObject[] buttons; // 按钮数组 
    private float timer = 0f; // 定时器
    void Start()
    {
        // 隐藏所有按钮
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
    }


    void Update()
    {
        if (timer >= 0.5f)
        {
            timer = 0f; // 重置定时器
            RandomButton(); // 调用随机按钮方法
        }
        else
        {
            timer += Time.deltaTime; // 增加定时器
        }
    }

    //按钮随机出现
    public void RandomButton()
    {
        // 随机选择一个按钮显示
        int randomIndex = Random.Range(0, buttons.Length);
        Vector2 randomPosition = new Vector2(Random.Range(-11f, 11f), Random.Range(-5f, 5f));
        buttons[randomIndex].transform.position = randomPosition; // 设置随机位置
        buttons[randomIndex].SetActive(true);
        Invoke("RandomButtonDisappear", 0.5f); // 1秒后调用RandomButtonDisappear方法
    }
    //按钮随机消失
    public void RandomButtonDisappear()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
    }
}
