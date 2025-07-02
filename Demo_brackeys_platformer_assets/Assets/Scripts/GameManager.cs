using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 单例模式实例

    public int lives; // 玩家生命值

    public Text livesText; // 显示生命值的UI文本

    public Vector3 respawnPoint; // 玩家重生位置

    public int deathCount = 0; // 玩家死亡次数
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        respawnPoint = PlayerController.instance.transform.position; // 初始化重生点为玩家初始位置

        if (SaveManager.instance.hasLoaded)
        {
            respawnPoint = SaveManager.instance.activeSave.respawnPosition; // 从存档加载重生点
            PlayerController.instance.transform.position = respawnPoint; // 设置玩家位置为重生点

            //lives = SaveManager.instance.activeSave.lives; // 从存档加载生命值
            deathCount = SaveManager.instance.activeSave.deathCount; // 从存档加载死亡次数
        }
        else
        {
            //SaveManager.instance.activeSave.lives = lives; // 初始化存档数据
            SaveManager.instance.activeSave.deathCount = deathCount; // 初始化存档数据
        }

        //livesText.text = "Lives: " + lives; // 更新UI文本显示生命值
        livesText.text = "deathCount: " + deathCount; // 更新UI文本显示死亡次数
    }


    void Update()
    {

    }

    public void Respawn()
    {
        StartCoroutine(RespawnCo());
    }

    public IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false); // 隐藏玩家对象

        //lives = lives - 1; // 减少生命值
        deathCount++; // 增加死亡次数
        //livesText.text = "Lives: " + lives; // 更新UI文本显示生命值
        livesText.text = "deathCount: " + deathCount; // 更新UI文本显示死亡次数

        //SaveManager.instance.activeSave.lives = lives; // 更新存档数据中的生命值
        SaveManager.instance.activeSave.deathCount = deathCount; // 更新存档数据中的死亡次数

        SaveManager.instance.Save(); // 保存游戏状态

        yield return new WaitForSeconds(0.5f); // 等待0.5秒


        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 重新加载当前场景

        //PlayerController.instance.transform.position = respawnPoint; // 将玩家位置设置为重生点

        //PlayerController.instance.gameObject.SetActive(true); // 显示玩家对象
    }
}
