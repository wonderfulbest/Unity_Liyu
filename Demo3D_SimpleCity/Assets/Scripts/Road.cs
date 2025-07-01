using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
//注释
public class Road : MonoBehaviour
{
    public static Road Instance; // 单例模式
    public GameObject[] gameObjects;
    public NavMeshSurface navMeshSurface;
    void Start()
    {
        Instance = this;
        for (int i = 0; i < gameObjects.Length; i++)
        {
            navMeshSurface = gameObjects[i].GetComponent<NavMeshSurface>();
            navMeshSurface.enabled = true;
        }

    }


    void Update()
    {

    }
}
