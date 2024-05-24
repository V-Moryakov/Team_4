using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{

    Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        KnightIsFall();
    }


    void KnightIsFall()
    {
        if (!FindObjectOfType<Knight>() && !anim.GetBool("KnightIsFall"))
        {
            GetComponent<Animator>().enabled = true;
            anim.SetBool("KnightIsFall", true);
            Invoke("Pos", 2);
        }
        if(FindObjectOfType<Knight>())
        {
            gameObject.transform.position = new Vector3(160.29f, -10.9f, 166.2f);
            anim.SetBool("KnightIsFall", false);
        }
    }

    void Pos()
    {
        GetComponent<Animator>().enabled = false;
        gameObject.transform.position = new Vector3(160.29f, -5.71f, 166.2f);
    }

}
