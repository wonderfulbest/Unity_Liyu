using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class CarRespawn : MonoBehaviour
{
    // 汽车预设位置列表
    public List<Transform> respawnPoints = new List<Transform>();

    // 当前汽车对象
    public GameObject car;

    // 复位键设置
    public KeyCode respawnKey = KeyCode.R;

    void Update()
    {
        // 检测R键按下
        if (Input.GetKeyDown(respawnKey))
        {
            RandomRespawnCar();
        }
    }

    void RandomRespawnCar()
    {
        // 确保有预设位置点
        if (respawnPoints.Count == 0)
        {
            Debug.LogWarning("没有设置复位点！");
            return;
        }

        // 随机选择一个位置点
        int randomIndex = Random.Range(0, respawnPoints.Count);
        Transform selectedPoint = respawnPoints[randomIndex];

        // 复位汽车
        car.transform.position = selectedPoint.position;
        car.transform.rotation = selectedPoint.rotation;

        // 如果需要，重置汽车物理状态
        Rigidbody carRigidbody = car.GetComponent<Rigidbody>();
        if (carRigidbody != null)
        {
            carRigidbody.velocity = Vector3.zero;
            carRigidbody.angularVelocity = Vector3.zero;
        }
    }
}