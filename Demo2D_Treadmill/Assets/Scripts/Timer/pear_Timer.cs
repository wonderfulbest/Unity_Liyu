using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class pear_Timer : MonoBehaviour
{
    public static pear_Timer instance; // 单例模式
    public GameObject projectile;
    public GameObject building;
    public GameObject remainderText;
    public bool isActive; // 用于控制投射物体和建筑的可见性
    public float timer; // 计时器，用于控制投射物体和建筑的出现时间间隔
    void Start()
    {
        instance = this;
        isActive = true;
        projectile.SetActive(true); // 确保在开始时投射物体不可见
        building.SetActive(true); // 确保在开始时建筑不可见
        remainderText.SetActive(false);

    }


    void Update()
    {
        if (isActive)
        {
            set_projectile_building(2f);
        }
        else if (!isActive)
        {
            set_projectile_building(100f);
            remainderText.SetActive(true); // 显示剩余时间文本
            timer -= Time.deltaTime; // 减少计时器
            remainderText.GetComponent<UnityEngine.UI.Text>().text = "剩余时间: " + Mathf.Ceil(timer).ToString(); // 更新剩余时间文本
            if (timer < 0f)
            {
                isActive = true; // 设置为可见
                remainderText.SetActive(false);
            }
        }
    }
    void set_projectile_building(float time)
    {
        BuildController.instance.buildTimer = time; // 重置建筑计时器
        ScreenEdgeSpawner.Instance.spawnInterval = time; // 重置生成间隔
    }
}
