using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//注释
public class CarController : MonoBehaviour
{
    public static CarController instance;
    private Rigidbody rb; // 车体刚体

    public WheelCollider[] wheelColliders; // 轮子碰撞器数组
    public Transform[] wheelMeshes; // 轮子模型数组
    public float motorTorque; // 驱动力
    public float maxSteerAngle = 45f; // 最大转向角度
    public float Speed; // 当前速度
    public float acceleration = 100f;// 加速度
    public int Gear = 0; // 当前档位

    private float HorizontalInput; // 水平输入
    private float VerticalInput; // 垂直输入
    public float currentSpeed; // 当前速度

    private void Start()
    {
        instance = this; // 设置单例实例
        rb = gameObject.GetComponent<Rigidbody>(); // 获取车体刚体组件       
        wheelColliders = GetComponentsInChildren<WheelCollider>();
        motorTorque = 0f;
        Gear = 0; // 初始化档位


    }
    private void Update()
    {

        GearState();
        CarMove();

    }
    void CarMove()
    {

        // 获取输入
        HorizontalInput = Input.GetAxis("Horizontal"); // 获取水平输入
        VerticalInput = Input.GetAxis("Vertical"); // 获取垂直输入
        //后轮驱动
        wheelColliders[2].motorTorque = motorTorque * VerticalInput; // 设置后轮的驱动力
        wheelColliders[3].motorTorque = motorTorque * VerticalInput; // 设置后轮的驱动力
        // 前轮转向
        wheelColliders[0].steerAngle = maxSteerAngle * HorizontalInput; // 设置前轮的转向角度
        wheelColliders[1].steerAngle = maxSteerAngle * HorizontalInput; // 设置前轮的转向角度

        // 更新轮子模型位置和旋转
        WheelConvers(wheelMeshes, wheelColliders);


        //如果按下空格键，进行刹车
        if (Input.GetKey(KeyCode.Space))
        {
            wheelColliders[2].brakeTorque = 10000f; // 设置刹车扭矩
            wheelColliders[3].brakeTorque = 10000f; // 设置刹车扭矩
        }
        else
        {
            wheelColliders[2].brakeTorque = 0f; // 取消刹车扭矩
            wheelColliders[3].brakeTorque = 0f; // 取消刹车扭矩
        }

        //如果按下Shift键，进行加速
        if (Input.GetKey(KeyCode.LeftShift) && Gear == 1)
        {
            rb.drag = 0.2f; // 减少阻力以模拟加速效果
            motorTorque += acceleration * Time.deltaTime; // 增加驱动力
        }
        else if (Gear == 1)
        {
            rb.drag = 0.4f; // 恢复正常阻力
            motorTorque = Mathf.Max(2500f, motorTorque - acceleration * Time.deltaTime); // 减少驱动力，确保不小于2500
        }
    }
    //挡位状态
    void GearState()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.E))
        {
            motorTorque = 2500f;// 设置驱动力
            Gear = 1; // 设置当前档位为1
        }
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Q))
        {
            motorTorque = 0f;// 设置驱动力为0
            Gear = 0; // 设置当前档位为0
        }

    }


    //跟随车轮组件进行移动
    private Vector3 wheelposturepos;// 车轮位置
    private Quaternion wheelposturerot;// 车轮旋转
    private void WheelConvers(Transform[] _wheelMeshes, WheelCollider[] _wheelColliders)
    {
        for (int i = 0; i < wheelColliders.Length; i++)
        {
            wheelposturepos = _wheelMeshes[i].position;// 获取前左轮的世界位置
            wheelposturerot = _wheelMeshes[i].rotation;// 获取前左轮的世界旋转
            _wheelColliders[i].GetWorldPose(out wheelposturepos, out wheelposturerot); // 获取前左轮的世界位置和旋转
            _wheelMeshes[i].position = wheelposturepos; // 设置前左轮模型的位置
            _wheelMeshes[i].rotation = wheelposturerot; // 设置前左轮模型的旋转
        }
    }
}
