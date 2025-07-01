using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class remainderButton : MonoBehaviour
{
    public GameObject remainderText;
    public GameObject quitButton;
    public GameObject playButton;
    void Start()
    {
        remainderText.SetActive(false);
        playButton.SetActive(true);
        quitButton.SetActive(false);
    }


    void Update()
    {

    }

    public void OnremainderButton()
    {

        // 显示提示文本
        remainderText.SetActive(true);
        playButton.SetActive(false);
        quitButton.SetActive(true);
    }

}