using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class LandMarkController : MonoBehaviour
{
    private static LandMarkController instance; // 单例模式
    private CapsuleCollider Collider; // 用于检测点击事件的胶囊体碰撞器

    void Start()
    {
        instance = this; // 初始化单例
        Collider = GetComponent<CapsuleCollider>();

    }


    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false); // 当玩家碰撞到地标时，隐藏地标
            LandMarkButton.Instance.isButtonOn = false; // 关闭按钮状态

        }
    }
}
