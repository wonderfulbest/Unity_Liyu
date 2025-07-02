using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {

    }

    void OnMouseDown()
    {
        // 当鼠标按下时，记录鼠标位置
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // 确保 z 轴为 0
        transform.position = mousePosition; // 将物体位置设置为鼠标位置
    }
    void OnMouseDrag()
    {
        // 当鼠标拖动时，更新物体位置
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // 确保 z 轴为 0
        transform.position = mousePosition; // 将物体位置设置为鼠标位置
    }
    void OnMouseUp()
    {
        // 当鼠标释放时，可以添加一些逻辑，比如放置物体等
        Debug.Log("Mouse released, object placed at: " + transform.position);
    }
    void OnMouseEnter()
    {
        // 当鼠标进入物体时，可以添加一些逻辑，比如高亮显示等
        Debug.Log("Mouse entered the object: " + gameObject.name);
    }
    void OnMouseExit()
    {
        // 当鼠标离开物体时，可以添加一些逻辑，比如取消高亮显示等
        Debug.Log("Mouse exited the object: " + gameObject.name);
    }
    void OnMouseOver()
    {
        // 当鼠标悬停在物体上时，可以添加一些逻辑，比如显示提示信息等
        Debug.Log("Mouse is over the object: " + gameObject.name);
    }

}
