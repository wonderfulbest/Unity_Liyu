using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//注释
public class SoundButton : MonoBehaviour
{
    public Sprite soundOnSprite; // 声音开启的图标
    public Sprite soundOffSprite; // 声音关闭的图标
    private Image img;
    private bool isSoundOn = true; // 声音状态，默认开启
    void Start()
    {
        img = GetComponent<Image>();
        img.sprite = soundOnSprite; // 初始化时设置为声音开启图标
        isSoundOn = true; // 初始化声音状态为开启
    }


    void Update()
    {

    }
    public void OnSoundButton()
    {
        if (isSoundOn)
        {
            isSoundOn = false; // 切换状态为声音关闭
            AudioListener.pause = false; // 暂停音频
            img.sprite = soundOffSprite; // 切换图标为声音关闭
        }
        else if (!isSoundOn)
        {
            isSoundOn = true; // 切换状态为声音开启
            AudioListener.pause = true; // 播放音频
            img.sprite = soundOnSprite; // 切换图标为声音开启
        }
    }
}