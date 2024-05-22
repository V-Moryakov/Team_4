using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLaser : MonoBehaviour
{

    public float lifeTime = 2;


    private void Start()
    {
        Invoke("DestroyObject", lifeTime);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }

}
