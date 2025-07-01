using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
using UnityEngine.UI;

public class GridRandomOrder : MonoBehaviour
{


    void Start()
    {
        RandomizeChildrenOrder();
    }
    void Update()
    {


    }
    public void RandomizeChildrenOrder()
    {
        // 获取所有子物体
        int childCount = transform.childCount;

        // 使用Fisher-Yates洗牌算法随机化顺序
        for (int i = 0; i < childCount; i++)
        {
            int randomIndex = Random.Range(i, childCount);
            transform.GetChild(randomIndex).SetSiblingIndex(i);
        }
    }

}