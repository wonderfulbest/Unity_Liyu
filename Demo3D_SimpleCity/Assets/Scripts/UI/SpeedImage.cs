using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class SpeedImage : MonoBehaviour
{
    public RectTransform needle;// 指针的RectTransform
    public Rigidbody carRigidbody;
    public float maxSpeed = 80f; // 表盘最大显示速度
    public float minNeedleAngle = 0f;
    public float maxNeedleAngle = 264f;

    void Update()
    {
        float speed = carRigidbody.velocity.magnitude * 3.6f; // km/h
        float speedNormalized = Mathf.Clamp01(speed / maxSpeed);
        float needleAngle = Mathf.Lerp(minNeedleAngle, maxNeedleAngle, speedNormalized);
        needle.localEulerAngles = new Vector3(0, 0, -needleAngle);
    }
}