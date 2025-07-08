using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class pear : MonoBehaviour
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
            pear_Timer.instance.isActive = false; // 设置为不可见
            pear_Timer.instance.timer = 100f;
            Destroy(gameObject);
        }
    }

}
