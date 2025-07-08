using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class ProjectileController : MonoBehaviour
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
            Player_information.instance.LessenScore(5f); // 玩家得分减10
            Destroy(gameObject); // 销毁子弹
        }
    }

}
