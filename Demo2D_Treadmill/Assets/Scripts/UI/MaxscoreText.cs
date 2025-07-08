using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//注释
public class MaxscoreText : MonoBehaviour
{
    private Text maxScoreText;
    void Start()
    {
        maxScoreText = GetComponent<Text>();
    }


    void Update()
    {
        maxScoreText.text = "最高分：" + MaxNumber.instance.GetMaxNumber();
    }
}
