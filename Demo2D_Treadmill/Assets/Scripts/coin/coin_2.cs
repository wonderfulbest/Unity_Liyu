using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class coin_2 : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    private Vector2 direction;
    void Start()
    {
        direction = GameObject.Find("Player").transform.position - transform.position; // 获取玩家位置
    }


    void Update()
    {
        MoveBuild(); // 每帧移动建筑
        if (gameObject.transform.position.y >= 6)
        {
            Destroy(gameObject);
        }
    }
    public void MoveBuild()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player_information.instance.AddScore(10);
            Destroy(gameObject); // 销毁硬币
        }
    }

}
