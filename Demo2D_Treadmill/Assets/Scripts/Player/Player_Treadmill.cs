using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class Player_Treadmill : MonoBehaviour
{
    public float speed = 0.2f; // 移动速度

    void Start()
    {

    }


    void Update()
    {
        Move(); // 移动方法调用
        Boundary(); // 边界检测

    }

    void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.transform.Translate(Vector2.up * speed); // 向上移动
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.Translate(Vector2.down * speed); // 向下移动
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Translate(Vector2.left * speed); // 向左移动
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Translate(Vector2.right * speed); // 向右移动
        }
    }

    void Boundary()
    {
        if (gameObject.transform.position.y > 2.5f)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, -2.5f);
        }
        else if (gameObject.transform.position.y < -2.5f)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, 2.5f);
        }
        else if (gameObject.transform.position.x > 6f)
        {
            gameObject.transform.position = new Vector2(-6f, gameObject.transform.position.y);
        }
        else if (gameObject.transform.position.x < -6f)
        {
            gameObject.transform.position = new Vector2(6f, gameObject.transform.position.y);
        }
    }
}
