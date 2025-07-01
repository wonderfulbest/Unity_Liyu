using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public Rigidbody Carbody;

    public enum CameraMode { FirstPerson, ThirdPerson }
    public CameraMode currentMode = CameraMode.ThirdPerson;
    CameraMode temp;

    // 玩家参考点（通常是角色的头部或身体中心）
    public Transform player;
    public Transform firstPersonAnchor; // 第一人称锚点（通常放在角色头部）

    // 相机参考
    public Camera mainCamera;

    // 第三人称参数
    public float thirdPersonDistance = 5f;// 玩家后方的距离
    public float thirdPersonHeight = 2f;// 玩家上方的高度
    public float thirdPersonAngle = 30f; // 相对于前方的角度
    // 第二人称参数
    public float secondPersonDistance = 5f;
    public float secondPersonHeight = 2f;
    public float secondPersonAngle = 30f; // 相对于前方的角度

    // 平滑移动参数
    public float moveSmoothTime = 0.8f;
    private Vector3 moveVelocity;

    // 平滑旋转参数
    public float rotationSmoothTime = 0.3f;




    private void Start()
    {
        instance = this; // 设置单例实例
        currentMode = CameraMode.ThirdPerson;
        temp = CameraMode.ThirdPerson; // 初始化临时模式为第三人称
    }
    void Update()
    {
        // 检测V键按下
        if (Input.GetKeyDown(KeyCode.V))
        {
            SwitchCameraMode();
            temp = currentMode; // 保存当前模式
        }

        // 根据当前模式更新相机位置
        UpdateCameraPosition();

        //if (currentMode == CameraMode.ThirdPerson)
        //{

        //    if (Input.GetMouseButton(1)) // 右键拖动
        //    {
        //        float mouseX = Input.GetAxis("Mouse X");
        //        float mouseY = Input.GetAxis("Mouse Y");
        //        // 旋转相机
        //        thirdPersonAngle += mouseX * 5f; // 绕Y轴旋转
        //        thirdPersonAngle += mouseY * 5f; // 绕X轴旋转（如果需要的话，可以调整角度）
        //    }
        //    float mouseScroll = Input.GetAxis("Mouse ScrollWheel");
        //    if (mouseScroll != 0f) // 鼠标滚轮缩放
        //    {
        //        thirdPersonDistance -= mouseScroll * 2f; // 缩放距离
        //        thirdPersonDistance = Mathf.Clamp(thirdPersonDistance, 2f, 10f); // 限制缩放范围
        //    }

        //}


        //SwitchToSecondPersonView();//前进为第三人称，倒车为第二人称
    }
    void SwitchCameraMode()
    {
        // 循环切换模式
        currentMode = (CameraMode)(((int)currentMode + 1) % System.Enum.GetValues(typeof(CameraMode)).Length);
    }

    void UpdateCameraPosition()
    {
        switch (currentMode)
        {
            case CameraMode.FirstPerson:
                UpdateFirstPerson();
                break;
            case CameraMode.ThirdPerson:
                UpdateThirdPerson();
                break;
                //case CameraMode.SecondPerson:
                //    UpdateSecondPerson();
                //    break;
        }
    }

    void UpdateFirstPerson()
    {
        currentMode = CameraMode.FirstPerson; // 确保当前模式为第一人称
        // 直接使用第一人称锚点位置       
        mainCamera.transform.position = firstPersonAnchor.position;
        mainCamera.transform.rotation = firstPersonAnchor.rotation;
    }

    void UpdateThirdPerson()
    {
        currentMode = CameraMode.ThirdPerson;
        Vector3 offsetDirection = Quaternion.Euler(0, thirdPersonAngle, 0) * player.forward;
        // 计算目标位置（玩家后方上方）
        Vector3 targetPosition = player.position - offsetDirection * thirdPersonDistance + Vector3.up * thirdPersonHeight;

        // 平滑移动
        mainCamera.transform.position = Vector3.SmoothDamp(
            mainCamera.transform.position,
            targetPosition,
            ref moveVelocity,
            moveSmoothTime);

        // 看向玩家
        Vector3 lookDirection = player.position - mainCamera.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
        mainCamera.transform.rotation = Quaternion.Slerp(
            mainCamera.transform.rotation,
            targetRotation,
            rotationSmoothTime);
    }

    //void UpdateSecondPerson()
    //{
    //    currentMode = CameraMode.SecondPerson;
    //    // 计算目标位置（玩家前方侧上方）
    //    Vector3 offsetDirection = Quaternion.Euler(0, secondPersonAngle, 0) * player.forward;
    //    Vector3 targetPosition = player.position - offsetDirection * secondPersonDistance + Vector3.up * secondPersonHeight;

    //    // 平滑移动
    //    mainCamera.transform.position = Vector3.SmoothDamp(
    //        mainCamera.transform.position,
    //        targetPosition,
    //        ref moveVelocity,
    //        moveSmoothTime);

    //    // 看向玩家
    //    Vector3 lookDirection = player.position - mainCamera.transform.position;
    //    Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
    //    mainCamera.transform.rotation = Quaternion.Slerp(
    //        mainCamera.transform.rotation,
    //        targetRotation,
    //        rotationSmoothTime);
    //}
    ////倒车切换第二人称视角
    //public void SwitchToSecondPersonView()
    //{
    //    WheelCollider[] wheels = CarController.instance.wheelColliders;
    //    float totalRPM = 0;

    //    foreach (var wheel in wheels)
    //    {
    //        totalRPM += wheel.rpm;
    //    }


    //    if (totalRPM < -10 && Input.GetKey(KeyCode.S))
    //    {
    //        // 倒车
    //        Invoke("UpdateSecondPerson", 2f);// 切换到第二人称视角
    //    }
    //    else if (totalRPM >= 10 && Input.GetKey(KeyCode.W))
    //    {
    //        // 前进或停止时切换回第三人称视角
    //        currentMode = temp;
    //    }
    //}

}
