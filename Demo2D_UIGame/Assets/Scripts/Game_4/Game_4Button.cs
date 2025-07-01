using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class Game_4Button : MonoBehaviour
{
    public GameObject Exitbutton;
    public GameObject Nextbutton;
    public AudioClip soundClip0;  // 将要播放的音效
    public AudioClip soundClip1;
    private AudioSource audioSource;
    int exitCount = 0;
    int nextCount = 0;
    private KeyCode[] ExitkeyCodes = new KeyCode[] { KeyCode.A, KeyCode.E, KeyCode.X, KeyCode.I, KeyCode.T, KeyCode.LeftShift, KeyCode.N };
    private KeyCode[] NextkeyCodes = new KeyCode[] { KeyCode.E, KeyCode.X, KeyCode.T, KeyCode.N };
    void Start()
    {
        Exitbutton.SetActive(false);
        Nextbutton.SetActive(false);
        audioSource = gameObject.AddComponent<AudioSource>();

    }


    void Update()
    {
        ExitState();
        NextState();
    }

    void ExitState()
    {
        int randomIndex = Random.Range(0, ExitkeyCodes.Length);
        if (Input.GetKeyDown(ExitkeyCodes[randomIndex]) && exitCount == 0)
        {
            exitCount = 1;
            PlaySound1();
        }
        else if (Input.GetKeyDown(ExitkeyCodes[randomIndex]) && exitCount == 1)
        {
            exitCount = 2;
            PlaySound1();
        }
        else if (Input.GetKeyDown(ExitkeyCodes[randomIndex]) && exitCount == 2)
        {
            exitCount = 3;
            PlaySound1();
        }
        else if (Input.GetKeyDown(ExitkeyCodes[randomIndex]) && exitCount == 3)
        {
            exitCount = 0;
            PlaySound1();
            Exitbutton.SetActive(true);
        }
        else if (Input.anyKeyDown)
        {
            PlaySound0();
        }
    }
    void NextState()
    {
        int randomIndex = Random.Range(0, NextkeyCodes.Length);
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.N) && nextCount == 0)
        {
            nextCount = 1;
            PlaySound1();
        }
        else if (Input.GetKeyDown(NextkeyCodes[randomIndex]) && nextCount == 1)
        {
            nextCount = 2;
            PlaySound1();
        }
        else if (Input.GetKeyDown(NextkeyCodes[randomIndex]) && nextCount == 2)
        {
            nextCount = 3;
            PlaySound1();
        }
        else if (Input.GetKeyDown(NextkeyCodes[randomIndex]) && nextCount == 3)
        {
            nextCount = 0;
            PlaySound1();
            Nextbutton.SetActive(true);
        }
        else if (Input.anyKeyDown)
        {
            PlaySound0();
        }
    }
    void PlaySound0()
    {
        audioSource.clip = soundClip0;
        audioSource.PlayOneShot(soundClip0);
    }
    void PlaySound1()
    {
        audioSource.clip = soundClip1;
        audioSource.PlayOneShot(soundClip1);
    }
}
