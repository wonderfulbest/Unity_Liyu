using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance; // 单例模式实例

    public Vector3 respawnPoint; // 玩家重生位置

    public int lives = 3; // 玩家生命值
    private void Awake()
    {
        instance = this;

    }
    void Start()
    {

    }


    void Update()
    {

    }
}
