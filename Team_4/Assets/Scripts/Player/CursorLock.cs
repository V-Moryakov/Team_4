using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock : MonoBehaviour
{

    bool ismenu;
    int sum;
    public GameObject[] UI;

    // Update is called once per frame
    void Update()
    {
        sum = 0;
        for(int i = 0; i < UI.Length; i++)
        {
            if (UI[i].active == false)
                sum++;
        }
        if(sum == UI.Length)
        {
            NotMenu();
        }
        else
        {
            IsMenu();
        }

        if(Input.GetMouseButtonDown(0) && !ismenu || !ismenu)
            Cursor.lockState = CursorLockMode.Locked;
        if (ismenu)
            Cursor.lockState = CursorLockMode.Confined;
    }

    public void IsMenu()
    {
        ismenu = true;
    }
    public void NotMenu()
    {
        ismenu = false;
    }

}
