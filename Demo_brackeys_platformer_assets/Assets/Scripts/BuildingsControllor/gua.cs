using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gua : MonoBehaviour
{
    public GameObject guaPrefab; // 预制体引用
    void Start()
    {
        guaPrefab = GetComponent<GameObject>();
        //强制加载预制体
        //if (guaPrefab == null)
        //{
        //    guaPrefab = Resources.Load<GameObject>("gua"); // 确保预制体路径正确
        //    if (guaPrefab == null)
        //    {
        //        Debug.LogError("无法加载预制体，请检查路径是否正确。");
        //    }
        //}

    }


    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            guaPrefab.SetActive(false); // 禁用当前游戏对象
        }
    }

}

