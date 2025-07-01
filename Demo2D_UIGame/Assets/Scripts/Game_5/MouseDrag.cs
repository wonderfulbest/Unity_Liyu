using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
using UnityEngine.EventSystems;

public class RestrictedDrag2D : MonoBehaviour, IBeginDragHandler
{
    private Vector3 offset;
    private bool canDrag = true;
    public LayerMask restrictedLayers; // 在Inspector中设置禁止层

    public void OnBeginDrag(PointerEventData eventData)
    {
        // 检查鼠标位置是否在禁止区域
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hit = Physics2D.OverlapPoint(mousePos, restrictedLayers);

        canDrag = hit == null;

        if (canDrag)
        {
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    public void OnMouseDrag()
    {
        if (!canDrag) return;

        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        newPos.z = transform.position.z;
        transform.position = newPos;
    }
}
