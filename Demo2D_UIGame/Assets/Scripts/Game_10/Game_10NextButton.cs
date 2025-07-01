using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class Game_10NextButton : MonoBehaviour
{
    public GameObject[] Images; // 按钮数组
    private int Index = 0; // 当前按钮索引
    void Start()
    {
        for (int i = 0; i < Images.Length; i++)
        {
            Images[i].SetActive(false); // 隐藏所有按钮
        }
    }


    void Update()
    {
        State();
    }
    public void OnDownButton()
    {
        Index++;
    }
    void State()
    {
        switch (Index)
        {
            case 1:
                Images[0].SetActive(true);
                break;
            case 2:
                Images[1].SetActive(true);
                break;
            case 3:
                Images[2].SetActive(true);
                break;

        }

    }
}
