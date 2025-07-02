using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenceChange : MonoBehaviour
{
    public static ScenceChange instance;
    public string sceneName; // 场景名称
    public int sceneIndex; // 场景索引

    void Start()
    {
        sceneIndex = 1; // 初始化场景索引
        sceneName = "Game_" + sceneIndex; // 初始化场景名称
    }

    void Update()
    {

    }

    public void LoadSceneByName(string _sceneName)
    {

        //设置玩家位置

        GameManager.instance.transform.position = new Vector3(-2.616f, -0.799f, 0f);
        SaveManager.instance.activeSave.respawnPosition = new Vector3(-2.616f, -0.799f, 0f); // 更新存档中的重生位置
        SaveManager.instance.Save(); // 保存游戏状态
        SceneManager.LoadScene(_sceneName);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // 检测是否是玩家碰撞
        {

            Invoke("LoadScene", 0.21f); // 延迟1秒调用加载场景方法

        }
    }

    public void LoadScene()
    {
        SaveData saveData = SaveManager.instance.activeSave; // 获取当前存档数据
        saveData.deathCount = 0; // 重置死亡次数
        LoadSceneByName(sceneName); // 加载指定场景

        sceneIndex++; // 增加场景索引
        sceneName = "Game_" + sceneIndex; // 更新场景名称
        Debug.Log("加载场景: " + sceneName); // 输出加载的场景名称
    }

    public void renew()
    {
        SaveManager.instance.DeleteSaveData(); // 删除存档数据
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 重新加载当前场景
    }
}
