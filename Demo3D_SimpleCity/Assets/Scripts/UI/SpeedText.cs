using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
using UnityEngine.UI;

public class SpeedText : MonoBehaviour
{
    public Text speedText;
    public Rigidbody carRigidbody; // 赛车刚体
    public float speedMultiplier = 3.6f; // 转换为km/h的系数

    void Update()
    {
        // 计算速度(km/h)
        float speed = carRigidbody.velocity.magnitude * speedMultiplier;
        // 更新UI文本
        speedText.text = Mathf.RoundToInt(speed) + " km/h";
    }
}