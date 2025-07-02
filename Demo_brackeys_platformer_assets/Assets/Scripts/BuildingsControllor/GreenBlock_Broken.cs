using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBlock_Broken : MonoBehaviour
{
    public Animator animator; // 用于播放破坏动画
    private bool isOn = true; // 是否存在
    private bool isBroken = false; // 是否被破坏

    void Start()
    {
        isOn = true;
        animator = GetComponent<Animator>();
        SaveManager.instance.activeSave.doorOpen = isOn; // 初始化存档数据中的按钮状态
    }
    void Update()
    {
        if (gameObject.activeSelf)
        {
            isOn = true; // 如果物体处于激活状态，则设置为存在
            isBroken = false; // 没有被破坏
        }
        else
        {
            isOn = false; // 如果物体处于非激活状态，则设置为不存在
            isBroken = true; // 被破坏
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.contacts[0].normal.y < -0.5f)
        {
            isBroken = true; // 被破坏
            animator.SetBool("isBroken", isBroken); // 播放破坏动画

            isOn = false;
            SaveManager.instance.activeSave.doorOpen = isOn;
            Invoke("setBroken", 0.5f); // 延迟0.5秒后调用setBroken方法
        }
    }

    void setBroken()
    {

        gameObject.SetActive(false); // 设置物体不可见


    }
}

