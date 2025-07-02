using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shortPlatform : MonoBehaviour
{
    private Rigidbody2D rigidbody2;
    private bool isReturning;
    public float speed = 1f; // 平台移动速度
    private Vector2 velocity;
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        isReturning = false; // 初始方向为右

    }


    void Update()
    {
        if (isReturning)
        {
            rigidbody2.velocity = new Vector2(-speed, 0f); // 向左移动
        }
        else if (!isReturning)
        {
            rigidbody2.velocity = new Vector2(speed, 0f); // 向右移动
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isReturning = !isReturning; // 碰撞到地面时切换方向

        }
        //if (collision.gameObject.CompareTag("Player"))
        //{
        //    // 碰撞到玩家，设置玩家的刚体为平台的刚体
        //    Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
        //    if (playerRigidbody != null)
        //    {
        //        playerRigidbody.isKinematic = true; // 设置玩家刚体为静态
        //        playerRigidbody.velocity = rigidbody2.velocity; // 传递平台的速度给玩家
        //    }
        //}
        //if (collision.gameObject.CompareTag("Player"))
        //{
        //    // 将玩家设为平台的子物体
        //    collision.transform.SetParent(transform);
        //}
    }

    //void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        // 玩家离开平台时取消父子关系
    //        collision.transform.SetParent(null);
    //    }
    //}

    //public Vector2 GetVelocity()
    //{
    //    return velocity;
    //}

}
