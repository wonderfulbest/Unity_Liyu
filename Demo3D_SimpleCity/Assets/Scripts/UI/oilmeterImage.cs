using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class oilmeterImage : MonoBehaviour
{
    public static oilmeterImage Instance; // 单例模式
    public RectTransform needle;// 指针的RectTransform
    public Rigidbody carRigidbody;
    public float minNeedleAngle;
    public float maxNeedleAngle;
    public float maxOil = 100f; // 油表最大值
    public float currentOil; // 当前油量
    public float oilConsumptionRate = 10f; // 油量消耗速率（每秒减少的油量）

    public GameObject Car;
    private void Start()
    {
        Instance = this;
        // 初始化油量
        currentOil = maxOil; // 假设初始油量为最大值
    }
    void Update()
    {
        float OilNormalized = Mathf.Clamp01(currentOil / maxOil);
        float needleAngle = Mathf.Lerp(minNeedleAngle, maxNeedleAngle, OilNormalized);
        needle.localEulerAngles = new Vector3(0, 0, +needleAngle);
        if (carRigidbody.velocity.magnitude > 1f) // 如果车速大于1m/s
        {
            ConsumeOil(oilConsumptionRate * Time.deltaTime);
        }

        if (currentOil <= 0)
        {
            Car.GetComponent<CarController>().enabled = false;
        }

    }
    //减少油量
    public void ConsumeOil(float amount)
    {
        if (currentOil > 0)
        {
            currentOil -= amount;
        }
        else if (currentOil <= 0)
        {
            Debug.Log("油量耗尽！");
            currentOil = 0; // 确保油量不小于0
        }
    }
    //增加油量
    public void AddOil(float amount)
    {
        if (currentOil < maxOil)
        {
            currentOil += amount;

            Debug.Log("正在加油！");
        }
        else if (currentOil >= maxOil)
        {
            Debug.Log("油量已满！");
            currentOil = maxOil; // 确保油量不超过最大值

        }
    }


}
