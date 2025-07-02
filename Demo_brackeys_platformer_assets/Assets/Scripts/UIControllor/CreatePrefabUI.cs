using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrefabUI : MonoBehaviour
{
    private bool isActive = false;
    public GameObject UI; // 在Inspector中拖入预制体
    void Start()
    {
        isActive = false;
        UI.gameObject.SetActive(false); // 初始时隐藏UI
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !isActive)
        {
            UI.gameObject.SetActive(true);
            isActive = true;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && isActive)
        {
            UI.gameObject.SetActive(false);
            isActive = false;
        }
    }
}
