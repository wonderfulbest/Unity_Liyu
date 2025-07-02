using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBox : MonoBehaviour
{
    public static Button instance; // 单例模式实例
    private bool isOn; // 按钮状态
    public Animator animator;
    public GameObject theGameObject; // 控制的物体

    void Start()
    {
        isOn = false; // 初始化按钮状态为未按下
        animator = GetComponent<Animator>();
        theGameObject.SetActive(false);

    }


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // 检测是否是玩家碰撞
        {
            isOn = true; // 切换按钮状态
            animator.SetBool("isOn", isOn); // 更新动画状态
            theGameObject.SetActive(isOn); // 根据按钮状态激活或禁用物体
            Debug.Log("Button toggled: " + isOn); // 输出调试信息
        }
    }

}
