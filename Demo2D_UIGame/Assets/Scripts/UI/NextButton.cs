using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
//注释
public class NextButton : MonoBehaviour
{
    int currentSceneIndex;
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }


    void Update()
    {

    }
    public void OnNextButtonClick()
    {
        currentSceneIndex++;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
