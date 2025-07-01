using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
using UnityEngine.UI;
public class refuelTimesText : MonoBehaviour
{
    public static refuelTimesText instance;
    public Text refuelTimestext;
    public int times = 0;
    void Start()
    {
        instance = this;
        times = 0;
    }

    void Update()
    {
        refuelTimestext.text = "加油次数：" + times;
    }
}
