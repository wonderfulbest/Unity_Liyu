using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance { get; private set; }
    public GameObject[] prefabs;
    public int poolSize = 20;

    private List<GameObject> objectPool;// 对象池

    void Start()
    {
        Instance = this;
        objectPool = new List<GameObject>();// 初始化对象池

        for (int i = 0; i < poolSize; i++)
        {
            int randomPrefab = Random.Range(0, prefabs.Length);
            GameObject obj = Instantiate(prefabs[randomPrefab]);
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }

    private void Update()
    {

    }
    public GameObject GetPooledObject()
    {
        // 查找可用的对象
        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        // 如果没有可用对象，创建新对象
        int randomPrefab = Random.Range(0, prefabs.Length);
        GameObject newObj = Instantiate(prefabs[randomPrefab]);
        objectPool.Add(newObj);
        return newObj;
    }
}