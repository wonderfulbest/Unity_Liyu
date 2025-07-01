using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class CircleController : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {
        if (gameObject.transform.position.y < -6.0f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 6.0f, gameObject.transform.position.z);
        }
        if (gameObject.transform.position.y > 6.0f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -6.0f, gameObject.transform.position.z);
        }
        if (gameObject.transform.position.x < -11.0f)
        {
            gameObject.transform.position = new Vector3(11.0f, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        if (gameObject.transform.position.x > 11.0f)
        {
            gameObject.transform.position = new Vector3(-11.0f, gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }
}
