using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
//注释
public class CameraFOVController : MonoBehaviour
{
    public static CameraFOVController Instance { get; private set; } // 单例模式
    [Header("拖动设置")]
    public float dragSpeed = 1f;
    public bool smoothMovement = true;
    public float smoothTime = 0.3f;


    private Vector3 dragOrigin;
    private Vector3 firstPosition;//最开始的位置
    private float firstSize;//最开始的视野大小
    private bool isDragging = false;


    public Camera orthoCamera;// 正交摄像机
    public float sizeChangeSpeed = 1f;
    public float minSize = 1f;
    public float maxSize = 10f;

    public Transform player;
    void Start()
    {
        orthoCamera = GetComponent<Camera>();
        firstPosition = orthoCamera.transform.position; // 记录初始位置
        firstSize = orthoCamera.orthographicSize; // 记录初始视野大小
    }
    void Update()
    {

        // 使用鼠标滚轮调整视野大小
        HandleCameraZoom();
        // 处理相机拖动
        HandleCameraDrag();
        if (Input.GetKeyDown(KeyCode.F))
        {
            FocusOnPlayer(player.position);
        }
    }

    public void FocusOnPlayer(Vector3 _playerPosition)
    {
        // 将摄像机位置设置为角色位置
        orthoCamera.transform.position = new Vector3(_playerPosition.x, orthoCamera.transform.position.y, _playerPosition.z);
        // 保持视野大小不变
        if (orthoCamera.orthographicSize > 50)
        {
            orthoCamera.orthographicSize -= 50;
        }
    }
    // 重置摄像机位置和视野大小
    public void ResetCamera()
    {
        orthoCamera.transform.position = firstPosition; // 重置位置
        orthoCamera.orthographicSize = firstSize; // 重置视野大小
    }
    //使用鼠标滚轮调整视野大小
    void HandleCameraZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            orthoCamera.orthographicSize -= scroll * sizeChangeSpeed * 10;
            orthoCamera.orthographicSize = Mathf.Clamp(
                orthoCamera.orthographicSize,
                minSize,
                maxSize
            );
        }

    }
    // 处理相机拖动
    void HandleCameraDrag()
    {
        // 鼠标左键按下时记录起点
        if (Input.GetMouseButtonDown(1))
        {
            dragOrigin = orthoCamera.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
        }
        // 鼠标左键按住时移动相机
        if (Input.GetMouseButton(1) && isDragging)
        {
            Vector3 difference = dragOrigin - orthoCamera.ScreenToWorldPoint(Input.mousePosition);
            orthoCamera.transform.position += difference;
        }
        // 鼠标左键释放时停止拖动
        if (Input.GetMouseButtonUp(1))
        {
            isDragging = false;
        }
    }
}