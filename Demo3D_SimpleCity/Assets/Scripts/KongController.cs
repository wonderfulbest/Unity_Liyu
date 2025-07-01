using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class KongController : MonoBehaviour
{
    public static KongController instance;
    public GameObject[] kong;

    void Start()
    {
        instance = this;
        setkongOn();

    }
    void Update()
    {
        setkong();
    }
    public void setkongOn()
    {
        for (int i = 0; i < kong.Length; i++)
        {
            kong[i].gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }
    public void setkongClose()
    {
        for (int i = 0; i < kong.Length; i++)
        {
            kong[i].gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
    public void setkong()
    {
        if (oilmeterImage.Instance.currentOil <= 30f)
        {
            setkongClose();
            reminderPanel.instance.set_textId(2);
        }
        else if (oilmeterImage.Instance.currentOil > 30f)
        {
            setkongOn();
        }
    }
}
