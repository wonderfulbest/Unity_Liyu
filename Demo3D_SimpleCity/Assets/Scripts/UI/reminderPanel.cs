using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//注释
public class reminderPanel : MonoBehaviour
{
    public static reminderPanel instance;
    public Text reminderText;
    private int textId;
    private string text01;
    private string text02;
    void Start()
    {
        instance = this;
        textId = 0;
        text01 = "快 跑！";
        text02 = "该去加油了";


    }


    void Update()
    {
        switch (textId)
        {
            case 0:
                reminderText.text = "";
                reminderText.gameObject.SetActive(false);
                break;
            case 1:
                reminderText.text = text01;
                reminderText.gameObject.SetActive(true);
                break;
            case 2:
                reminderText.text = text02;
                reminderText.gameObject.SetActive(true);
                break;
        }
    }
    public void set_textId(int i)
    {
        textId = i;
        Invoke("textId_0", 3f);
    }
    void textId_0()
    {
        textId = 0;
    }
}
