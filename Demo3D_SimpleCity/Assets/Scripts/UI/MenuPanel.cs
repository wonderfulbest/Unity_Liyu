using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
using UnityEngine.UI; // 如果需要UI元素

public class MenuPanel : MonoBehaviour
{
    public static MenuPanel instance;
    public GameObject Menu;
    public GameObject Mod;
    public bool isMenu = false;

    private void Start()
    {
        instance = this;
        Menu.SetActive(false);
        Mod.SetActive(false);
        isMenu = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!CameraChanger.Instance.isMaxMapActive)
            {
                if (isMenu)
                {
                    Resume();
                    Menu.SetActive(false);
                    ModButton.instance.ismod = false;
                    ModButton.instance.mod.SetActive(false);
                }
                else if (!isMenu)
                {
                    Pause();
                    Menu.SetActive(true);
                }
            }
            else if (CameraChanger.Instance.isMaxMapActive)
            {
                return;
            }
        }
    }

    public void Resume()
    {

        Time.timeScale = 1f;
        AudioListener.pause = false;
        isMenu = false;
    }

    void Pause()
    {

        Time.timeScale = 0f;
        AudioListener.pause = true;
        isMenu = true;
    }
}
