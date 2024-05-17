using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock : MonoBehaviour
{

    public GameObject menu;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && menu.active == false || menu.active == false)
            Cursor.lockState = CursorLockMode.Locked;
        if (menu.active == true)
            Cursor.lockState = CursorLockMode.Confined;
    }
}
