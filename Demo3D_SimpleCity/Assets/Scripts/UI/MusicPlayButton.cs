using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//注释
public class MusicPlayButton : MonoBehaviour
{
    public Sprite sprite_0;
    public Sprite sprite_1;

    private Image img;
    private bool isMusicPlay;
    void Start()
    {
        img = GetComponent<Image>();
        img.sprite = sprite_1;
        isMusicPlay = true;
    }
    void Update()
    {

    }

    public void MusicPlayOn()
    {
        isMusicPlay = true;
        img.sprite = sprite_1;
        MusicController.Instance.TogglePlayPause();
    }
    public void MusicPlayOff()
    {
        isMusicPlay = false;
        img.sprite = sprite_0;
        MusicController.Instance.TogglePlayPause();
    }

    public void setMusicPlay()
    {
        if (isMusicPlay)
        {
            MusicPlayOff();
        }
        else if (!isMusicPlay)
        {
            MusicPlayOn();
        }
    }
}
