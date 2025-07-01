using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
using UnityEngine.UI;
public class oilmeterText : MonoBehaviour
{
    public Text oilText;

    void Update()
    {
        if (oilmeterImage.Instance.currentOil >= 0)
        {
            oilText.text = "Oil: " + Mathf.RoundToInt(oilmeterImage.Instance.currentOil) + " L";
        }
    }
}
