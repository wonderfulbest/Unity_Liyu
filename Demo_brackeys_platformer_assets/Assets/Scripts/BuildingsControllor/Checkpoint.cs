using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public static Checkpoint instance; // 单例模式实例
    public Animator anim; // 检查点的动画控制器
    public static bool isOn; // 检查点是否被激活
    void Start()
    {
        isOn = false;
    }


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // 检测是否是玩家碰撞
        {
            isOn = true;
            anim.SetBool("isOn", true); // 播放检查点激活动画
            GameManager.instance.respawnPoint = transform.position; // 更新重生点为当前检查点位置
            SaveManager.instance.activeSave.respawnPosition = transform.position; // 更新存档中的重生位置
            SaveManager.instance.Save(); // 保存游戏状态

            Debug.Log("Checkpoint activated at: " + transform.position); // 输出调试信息
        }
    }

}
