using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释

public class PoCarAI : MonoBehaviour
{
    public static PoCarAI Instance;
    public float detectionRange = 30f; // 检测范围
    public float chaseSpeed = 15f;    // 追逐速度
    public float normalSpeed = 8f;    // 正常巡逻速度
    public float rotationSpeed = 3f;  // 转向速度

    private Transform player;         // 玩家参考

    void Start()
    {
        Instance = this;
        // 找到玩家对象（假设玩家标签为"Player"）
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // 计算与玩家的距离
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // 检测玩家是否进入范围
        if (distanceToPlayer <= detectionRange)
        {
            ChasePlayer();
        }
        else
        {
            Patrol(); // 正常巡逻行为
        }
    }

    void ChasePlayer()
    {
        // 计算朝向玩家的方向
        Vector3 direction = (player.position - transform.position).normalized;

        // 计算目标旋转
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        // 平滑旋转
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            lookRotation,
            Time.deltaTime * rotationSpeed
        );

        // 向前移动
        transform.Translate(Vector3.forward * chaseSpeed * Time.deltaTime);
    }

    void Patrol()
    {
        AICar_Patrol.Instance.patrol();
    }

    // 可视化检测范围（仅在编辑器中可见）
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}