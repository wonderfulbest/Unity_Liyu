using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//注释
public class Exit : MonoBehaviour
{
    private Collider2D exitCollider;
    void Start()
    {
        exitCollider = GetComponent<Collider2D>();
    }


    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Circle"))
        {
            // 触发退出游戏逻辑
            Debug.Log("Exit Game");
            SceneManager.LoadScene(0);
        }
    }
}
