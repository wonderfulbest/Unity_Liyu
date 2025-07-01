using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
using UnityEngine.AI;
public class Pathfinding : MonoBehaviour
{
    public static Pathfinding Instance; // 单例模式
    public Transform target; // 标记点
    public LineRenderer pathRenderer; // 用于显示路径的LineRenderer

    [SerializeField] private float pathUpdateInterval = 0.2f;// 路径更新间隔时间
    private float lastUpdateTime;// 上次更新路径的时间

    private NavMeshAgent agent;

    void Start()
    {
        Instance = this; // 初始化单例
        agent = GetComponent<NavMeshAgent>();

        agent.enabled = false;
    }

    void Update()
    {
        if (LandMarkButton.Instance.isButtonOn == true)
        {
            // 计算路径
            agent.enabled = true; // 禁用导航网格代理
            //Road.Instance.navMeshSurface.enabled = true; // 启用导航网格表面
            // 显示路径
            if (Time.time - lastUpdateTime > pathUpdateInterval && agent.enabled == true)
            {
                UpdatePath();
                lastUpdateTime = Time.time;
            }

        }
        else if (LandMarkButton.Instance.isButtonOn == false)
        {
            // 如果按钮未开启，清除路径
            pathRenderer.positionCount = 0;
            agent.enabled = false; // 启用导航网格代理
            //Road.Instance.navMeshSurface.enabled = false; // 禁用导航网格表面
        }


    }

    void DrawPath()
    {
        pathRenderer.positionCount = agent.path.corners.Length;
        pathRenderer.SetPositions(agent.path.corners);
    }
    public void SetNewTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void UpdatePath()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            DrawPath();
        }
    }
}