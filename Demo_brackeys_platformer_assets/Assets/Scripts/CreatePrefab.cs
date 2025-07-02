using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePrefab : MonoBehaviour
{
    // 在Inspector中拖入预制体
    public GameObject prefabToSpawn;

    // 可选：设置生成位置（如果不设置，将在默认位置生成）
    public Vector2 spawnPosition = Vector2.zero;
    void Start()
    {

    }
    void Update()
    {

    }

    public void SpawnPrefab()
    {
        if (prefabToSpawn != null)
        {
            Vector3 spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnPos.z = 0; // 确保 z 轴为 0，避免在3D空间中生成
            GameObject newPrebal = Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
            newPrebal.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Prefab to spawn is not assigned!");
        }
    }

    public void SpawnPrefabAtMousePosition()
    {
        if (prefabToSpawn != null)
        {
            Vector2 spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
        }
    }



}
