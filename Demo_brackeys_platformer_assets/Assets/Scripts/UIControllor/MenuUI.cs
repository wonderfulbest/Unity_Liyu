using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public static MenuUI Instance;
    public GameObject pauseMenuUI; // 暂停菜单的UI对象
    public bool IsPaused;
    public bool IsGameOver { get; private set; }


    void Start()
    {
        Instance = this; // 确保单例模式
        IsPaused = false;
        IsGameOver = false;
        pauseMenuUI.SetActive(false); // 确保暂停菜单初始时隐藏
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Switch_Pause_Resume();
        }

    }
    public void Switch_Pause_Resume()
    {
        IsPaused = !IsPaused; // 切换暂停状态
        pauseMenuUI.SetActive(IsPaused); // 根据暂停状态显示或隐藏暂停菜单
        if (IsPaused)
        {
            PauseGame(); // 如果是暂停状态，调用暂停方法
        }
        else
        {
            ResumeGame(); // 如果是恢复状态，调用恢复方法
        }
    }
    public void PauseGame()
    {
        IsPaused = true; // 设置暂停状态为true
        //pauseMenuUI.SetActive(true); // 显示暂停菜单
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        IsPaused = false; // 设置暂停状态为false
        //pauseMenuUI.SetActive(false);// 隐藏暂停菜单
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        IsPaused = false;
        IsGameOver = false;
        Time.timeScale = 1f;
        SaveManager.instance.DeleteSaveData(); // 删除存档数据
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }


}