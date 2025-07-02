using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlock : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 1f;// 速度
    public float distance = 5f; // 距离
    private Vector2 startPosition; // 起始位置
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position; // 记录起始位置
    }


    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player") &&
            collision.contacts[0].normal.y > 0.5f) // 从下方碰撞时触发
        {
            // 触发事件，例如重置玩家位置或减少生命值
            GameManager.instance.Respawn();

        }
    }


}
