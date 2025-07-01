using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class PetrolStation : MonoBehaviour
{
    private MeshCollider Coll;
    public GameObject panel; // 加油站面板

    void Start()
    {
        Coll = GetComponent<MeshCollider>();
        panel.SetActive(false); // 初始时隐藏加油站面板
    }

    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {

                // 检查油量是否已满
                if (oilmeterImage.Instance.currentOil < oilmeterImage.Instance.maxOil)
                {
                    // 增加油量
                    oilmeterImage.Instance.AddOil(1f);
                    Debug.Log("加油成功！当前油量：" + oilmeterImage.Instance.currentOil);
                }
                else if ((oilmeterImage.Instance.currentOil >= oilmeterImage.Instance.maxOil) && refuelTimesText.instance.times == 0)
                {
                    oilmeterImage.Instance.currentOil = oilmeterImage.Instance.maxOil;
                    Debug.Log("油量已满，无法加油！");
                    panel.SetActive(true);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (oilmeterImage.Instance.currentOil > oilmeterImage.Instance.maxOil - 5)
            {
                refuelTimesText.instance.times++;
                if (refuelTimesText.instance.times == 1)
                {
                    CreatePoCar_trace.Instance.OnSpawnEnemy();
                }
                CreatePoCar_patrol.Instance.OnSpawnEnemy();
            }
        }
    }
}
