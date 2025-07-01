using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class gameObjectController : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {
        if (gameObject.transform.position.y < -20)
        {
            // 如果物体的y坐标小于-10，则销毁该物体
            Destroy(gameObject);
        }

    }
}
