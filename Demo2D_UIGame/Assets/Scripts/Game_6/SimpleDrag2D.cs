using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class SimpleDrag2D : MonoBehaviour
{
    private void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z; // 保持z轴不变
        transform.position = mousePos;
    }
}