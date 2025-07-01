using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class MusicController : MonoBehaviour
{
    public static MusicController Instance;
    public List<AudioClip> playlist; // 歌曲列表
    private AudioSource audioSource;
    private int currentTrackIndex = 0;

    private float pauseTime;
    private bool isPaused;
    void Start()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
        isPaused = false;
        PlayNextTrack();
    }

    void Update()
    {
        // 检查当前歌曲是否播放完毕且没有循环
        if (!audioSource.isPlaying && !audioSource.loop)
        {
            PlayNextTrack();
        }
    }

    public void PlayNextTrack()
    {
        if (playlist.Count == 0) return;

        audioSource.clip = playlist[currentTrackIndex];
        audioSource.Play();

        // 更新索引，循环播放
        currentTrackIndex = (currentTrackIndex + 1) % playlist.Count;
    }

    public void PlayLastTrack()
    {
        if (playlist.Count == 0) return;

        audioSource.clip = playlist[currentTrackIndex];
        audioSource.Play();

        // 更新索引，循环播放
        currentTrackIndex = (currentTrackIndex - 1 + playlist.Count) % playlist.Count;
    }
    public void TogglePlayPause()
    {
        if (audioSource.isPlaying)
        {
            // 暂停音乐
            pauseTime = audioSource.time;
            audioSource.Pause();
            isPaused = true;
        }
        else
        {
            // 继续播放
            if (isPaused)
            {
                // 从暂停位置继续
                audioSource.time = pauseTime;
            }
            else
            {
                // 如果是第一次播放，从头开始
                audioSource.time = 0;
            }
            audioSource.Play();
            isPaused = false;
        }


    }
}