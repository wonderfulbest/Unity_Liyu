using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//注释
public class HomeButton : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {

    }

    public void OnHomeButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start_0");
    }
}
