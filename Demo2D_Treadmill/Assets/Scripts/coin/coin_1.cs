using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class coin : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {
        if (transform.position.y < -2.34f) // 如果硬币掉出屏幕下方
        {
            Destroy(gameObject); // 销毁硬币
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player_information.instance.AddScore(10f);
            Destroy(gameObject);
        }
    }
    //public void CoinRain()
    //{
    //    Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
    //    rb.isKinematic = true;
    //    rb.gravityScale = 0.5f; // 设置重力


    //}
}
