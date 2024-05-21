using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOnClick : MonoBehaviour
{

    public GameObject Fire;
    public Transform Source;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            FireCreat();
        }
    }

    void FireCreat()
    {
        Instantiate(Fire, Source.position, Source.rotation);
    }

}
