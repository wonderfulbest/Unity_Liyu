using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change2DLayerOrder : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // 获取SpriteRenderer组件
        spriteRenderer = GetComponent<SpriteRenderer>();


        SetSortingOrder(-1);            // 设置图层顺序
    }

    // 设置排序图层（通过名称）
    //public void SetSortingLayer(string layerName)
    //{
    //    spriteRenderer.sortingLayerName = layerName;
    //}

    // 设置排序图层（通过ID）
    //public void SetSortingLayer(int layerID)
    //{
    //    spriteRenderer.sortingLayerID = layerID;// 设置图层ID
    //}

    // 设置图层内顺序（数值越大显示在越前面）
    public void SetSortingOrder(int order)
    {
        spriteRenderer.sortingOrder = order;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SetSortingOrder(2);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SetSortingOrder(-1);
        }
    }
}
