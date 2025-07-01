using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释

public class AICar_Patrol : MonoBehaviour
{
    public static AICar_Patrol Instance;
    public Transform[] waypoints;//寻路点
    private int currentWaypoint = 0;
    private float speed;//巡逻速度
    public float rotationSpeed;// 转向速度

    private void Start()
    {
        Instance = this;
        speed = PoCarAI.Instance.normalSpeed;
        rotationSpeed = PoCarAI.Instance.rotationSpeed;
    }
    void Update()
    {

    }
    public void patrol()
    {
        if (waypoints.Length == 0) return;

        Vector3 targetDirection = waypoints[currentWaypoint].position - transform.position;
        float step = rotationSpeed * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 2f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }
    }
}