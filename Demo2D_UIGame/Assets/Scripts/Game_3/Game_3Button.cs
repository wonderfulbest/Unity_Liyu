using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class Game_3Button : MonoBehaviour
{
    public GameObject clrcle;
    private Rigidbody2D clrclerb;
    private int direction = 0; // 0: up, 1: right, 2: down, 3: left
    void Start()
    {
        clrclerb = clrcle.GetComponent<Rigidbody2D>();
    }


    void Update()
    {

    }

    public void OnClick()
    {
        direction = (direction + 1) % 4; // 每次点击改变方向
        State();
    }

    public void State()
    {
        switch (direction)
        {
            case 0:
                clrclerb.velocity = new Vector2(0, 5);
                break;
            case 1:
                clrclerb.velocity = new Vector2(5, 0);
                break;
            case 2:
                clrclerb.velocity = new Vector2(0, -5);
                break;
            case 3:
                clrclerb.velocity = new Vector2(-5, 0);
                break;
        }
    }
}