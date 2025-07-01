using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//注释
using UnityEngine.UI;
public class refuelPanel : MonoBehaviour
{
    public Button yesButton; // 确认按钮
    public Button noButton; // 取消按钮   
    public Text refuelText;

    private int step = 0; // 步骤计数器
    private bool isButtonOn = false;
    void Start()
    {
        yesButton.onClick.AddListener(OnYesButtonClicked);
        noButton.onClick.AddListener(OnNoButtonClicked);
        isButtonOn = false; // 初始化按钮状态
        begin(); // 初始化面板内容

    }


    void Update()
    {
        state();
        yesButton.onClick.AddListener(OnYesButtonClicked);
        noButton.onClick.AddListener(OnNoButtonClicked);
    }
    void begin()
    {
        step = 0;
        refuelText.text = "已加满油，请支付"; // 设置提示文本
        yesButton.GetComponentInChildren<Text>().text = "真的要支付？"; // 设置按钮文本
        noButton.GetComponentInChildren<Text>().text = "不支付行不行？"; // 设置按钮文本
        isButtonOn = false;
    }
    void then01()
    {
        step = 1;
        refuelText.text = "一共88888888￥";
        yesButton.GetComponentInChildren<Text>().text = "好的，等我去银行取钱";
        noButton.GetComponentInChildren<Text>().text = "有毛病";
        isButtonOn = false;
    }
    void then02()
    {
        step = 2;
        refuelText.text = "不支付你养我啊？";
        yesButton.GetComponentInChildren<Text>().text = "好啊，等我赚到钱再说";
        noButton.GetComponentInChildren<Text>().text = "有毛病";
        isButtonOn = false;
    }
    void then01_1()
    {
        step = 11;
        refuelText.text = "报警，有人要去抢银行";
        yesButton.GetComponentInChildren<Text>().text = "啊？";
        noButton.GetComponentInChildren<Text>().text = "啊！";
        isButtonOn = false;
    }
    void then01_2()
    {
        step = 12;
        refuelText.text = "报警，有人骂我";
        yesButton.GetComponentInChildren<Text>().text = "不是哥们，开玩笑的";
        noButton.GetComponentInChildren<Text>().text = "有毒吧";
        isButtonOn = false;
    }
    void then02_1()
    {
        step = 21;
        refuelText.text = "报警，有人想赚快钱";
        yesButton.GetComponentInChildren<Text>().text = "啊？";
        noButton.GetComponentInChildren<Text>().text = "啊！";
        isButtonOn = false;
    }
    void then02_2()
    {
        step = 22;
        refuelText.text = "报警，有人骂我";
        yesButton.GetComponentInChildren<Text>().text = "不是哥们，开玩笑的";
        noButton.GetComponentInChildren<Text>().text = "有毒吧";
        isButtonOn = false;
    }
    void endly()
    {
        reminderPanel.instance.set_textId(1);
        gameObject.SetActive(false);

    }
    //状态机
    void state()
    {
        switch (step)
        {
            case 0:
                begin(); // 初始状态
                break;
            case 1:
                then01(); // 第一步
                break;
            case 2:
                then02(); // 第二步
                break;
            case 11:
                then01_1(); // 第一步的分支1
                break;
            case 12:
                then01_2(); // 第一步的分支2
                break;
            case 21:
                then02_1(); // 第二步的分支1
                break;
            case 22:
                then02_2(); // 第二步的分支2
                break;
        }
    }
    public void OnYesButtonClicked()
    {
        if (step == 0 && !isButtonOn)
        {
            isButtonOn = true;
            step = 1; // 进入第一步
        }
        else if (step == 1 && !isButtonOn)
        {
            isButtonOn = true;
            step = 11; // 进入第一步的分支1
        }
        else if (step == 2 && !isButtonOn)
        {
            isButtonOn = true;
            step = 21; // 进入第二步的分支1
        }
        else if ((step == 11 || step == 21) && !isButtonOn)
        {
            endly();
        }

    }
    public void OnNoButtonClicked()
    {
        if (step == 0 && !isButtonOn)
        {
            isButtonOn = true;
            step = 2; // 进入第二步
        }
        else if (step == 1 && !isButtonOn)
        {
            isButtonOn = true;
            step = 12; // 进入第一步的分支2
        }
        else if (step == 2 && !isButtonOn)
        {
            isButtonOn = true;
            step = 22; // 进入第二步的分支2
        }
        else if ((step == 12 || step == 22) && !isButtonOn)
        {
            endly();
        }
    }
}
