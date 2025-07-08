using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class apple : MonoBehaviour
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
            Player_information.instance.AddScore(1000f);
            Destroy(gameObject);
        }
    }

}
