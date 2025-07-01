using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class ModButton : MonoBehaviour
{
    public static ModButton instance;
    public GameObject mod;
    public bool ismod;
    void Start()
    {
        instance = this;
        ismod = false;
        mod.SetActive(ismod);
    }


    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    ismod = false;
        //    mod.SetActive(false);
        //}
    }

    public void setMod()
    {
        ismod = !ismod;
        mod.SetActive(ismod);
    }
}
