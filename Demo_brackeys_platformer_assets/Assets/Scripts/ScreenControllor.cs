using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ScreenControllor : MonoBehaviour
{
    public Camera mainCamera;// 主摄像机
    public float zoomSpeed = 2f;// 缩放速度
    public float panSpeed = 5f;      // 移动速度
    private Vector3 dragOrigin;// 鼠标拖动的起始位置
    private bool isDragging = false;// 是否正在拖动摄像机
    public float dragSpeed = 1f;// 拖动速度
    public float minZoom = 0.1f;  // 设置最小正值
    public float maxZoom = 5f;// 设置最大正值

    void Start()
    {



    }


    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");// 获取鼠标滚轮的输入值

        // 缩放摄像机
        if (scroll != 0)
        {
            float newSize = mainCamera.orthographicSize - scroll * zoomSpeed;
            mainCamera.orthographicSize = Mathf.Clamp(newSize, minZoom, maxZoom);
        }



        //移动屏幕
        if (Input.GetMouseButtonDown(1)) // 右键按下
        {
            dragOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);// 获取鼠标在世界空间中的位置
            isDragging = true;
        }

        // 鼠标释放时停止拖动
        if (Input.GetMouseButtonUp(1))
        {
            isDragging = false;
        }

        // 拖动过程中移动相机
        if (isDragging)
        {
            Vector3 difference = dragOrigin - Camera.main.ScreenToWorldPoint(Input.mousePosition);// 计算鼠标拖动的差值
            Camera.main.transform.position += difference * dragSpeed;
        }

    }

}
