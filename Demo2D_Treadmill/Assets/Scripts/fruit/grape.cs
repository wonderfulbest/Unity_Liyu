using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class grape : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            coinController.instance.CreateCoinRain(); // 创建金币雨
            Destroy(gameObject);
        }
    }
}
