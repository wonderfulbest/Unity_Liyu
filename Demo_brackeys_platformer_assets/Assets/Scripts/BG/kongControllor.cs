using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class kongControllor : MonoBehaviour
{



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
            // 触发事件，例如重置玩家位置或减少生命值
            GameManager.instance.Respawn();
            //collision.gameObject.transform.position = GameManager.instance.respawnPoint; // 重置玩家位置到重生点
            Debug.Log("Player hit by Kong! Death count: " + GameManager.instance.deathCount);
        }
    }
}
