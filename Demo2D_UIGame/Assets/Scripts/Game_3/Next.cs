using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//注释
public class Next : MonoBehaviour
{
    private Collider2D nextCollider;
    int currentSceneIndex;
    private bool isOnTrigger = false;
    void Start()
    {
        nextCollider = GetComponent<Collider2D>();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        isOnTrigger = false;
    }


    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Circle") && !isOnTrigger)
        {
            isOnTrigger = true; // 确保只触发一次
            // 触发下一关逻辑
            currentSceneIndex++;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
