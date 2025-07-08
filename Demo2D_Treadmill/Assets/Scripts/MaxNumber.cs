using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class MaxNumber : MonoBehaviour
{
    public static MaxNumber instance;
    void Start()
    {
        instance = this;
    }


    void Update()
    {

    }

    public float GetMaxNumber()
    {

        GameData gameData = SaveSystem.LoadDataGameData();
        List<float> score = gameData.GetPlayerData(gameData.currentPlayerName).scores;
        if (score.Count == 0)
        {
            Debug.Log("没有分数记录");
            return 0f; // 如果没有分数，返回0
        }
        else
        {
            float maxNumber = score[0];
            for (int i = 0; i < score.Count; i++)
            {
                if (score[i] > maxNumber)
                {
                    maxNumber = score[i];
                }
            }
            return maxNumber;
        }

    }
}
