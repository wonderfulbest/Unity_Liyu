using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//注释
public class SubmitButton : MonoBehaviour
{
    public InputField playerNameInputField;
    public GameObject accountPanel;
    void Start()
    {

    }


    void Update()
    {

    }
    public void OnSubmitButtonClick()
    {
        if (playerNameInputField.text != "")
        {
            // 保存玩家名字
            Player_information.instance.SaveName(playerNameInputField.text);

        }
        else
        {
            Debug.LogWarning("玩家名字不能为空！");
        }
        accountPanel.SetActive(false);
    }
}
