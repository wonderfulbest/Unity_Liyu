using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
// 简单的跟随脚本
public class MiniMapFollow : MonoBehaviour
{
    public Transform player;// 玩家或目标对象的Transform
    public float height = 20f;

    void LateUpdate()
    {
        transform.position = player.position + Vector3.up * height;
        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}
