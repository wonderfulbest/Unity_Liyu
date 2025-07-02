using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public GameObject textPanel;
    private bool isPlayerInRange = false;
    private bool isActive = false;
    void Start()
    {
        textPanel.SetActive(false);
        isPlayerInRange = false;
        isActive = false;
    }


    void Update()
    {
        if (isPlayerInRange)
        {
            if (Input.GetKeyDown(KeyCode.F) && !isActive)
            {
                textPanel.SetActive(true);
                isActive = true;
            }
            else if (Input.GetKeyDown(KeyCode.F) && isActive)
            {
                textPanel.SetActive(false);
                isActive = false;
            }
        }
        else if (!isPlayerInRange)
        {
            textPanel.SetActive(false);
            isActive = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
