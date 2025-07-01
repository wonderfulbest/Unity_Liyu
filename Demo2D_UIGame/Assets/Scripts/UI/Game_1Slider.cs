using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//注释
public class Game_1Slider : MonoBehaviour
{
    public Slider slider; // 引用Slider组件
    private Slider sliderSwitch;
    void Start()
    {
        sliderSwitch = GetComponent<Slider>(); // 获取Slider组件
    }


    void Update()
    {
        slider.value = sliderSwitch.value;
    }
}
