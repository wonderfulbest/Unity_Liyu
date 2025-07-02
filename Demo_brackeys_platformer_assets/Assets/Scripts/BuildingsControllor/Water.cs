using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float speed = 1f; // 水流速度
    void Start()
    {

    }


    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.rigidbody.velocity = new Vector3(0f, -speed, 0f); // 设置玩家在水中的速度
        }
    }
}
