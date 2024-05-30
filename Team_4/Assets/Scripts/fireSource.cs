using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireSource : MonoBehaviour
{
    Vector3 front;
    bool isEnemy;
    bool up;
    private void Start()
    {
        RotateUp();
    }

    private void Update()
    {
        if(Input.GetMouseButton(0) && !isEnemy)
        {
            transform.rotation = new Quaternion(0,0,0,0);
        }
        Raycast();
        if(transform.rotation.x >= 90)
        {
            up = false;
        }
        if (transform.rotation.x <= -90)
        {
            up = true;
        }

        if (up && !isEnemy)
        {
            RotateUp();
            Raycast();
        }

        else if (!up && !isEnemy)
        {
            RotateDown();
            Raycast();
        }
    }


    void Raycast()
    {
        var diraction = transform.forward;

        RaycastHit hit;
        if(Physics.Raycast(transform.position, diraction, out hit))
        {
            if(hit.collider != null)
            {
                if(hit.collider.CompareTag("Enemy") || hit.collider.CompareTag("weapon"))
                {
                    isEnemy = true;
                    //Debug.Log("1");
                }
                else
                {
                    isEnemy = false;
                }
            }
            else
            {
                isEnemy = false;
            }
        }
        else
        {
            isEnemy = false;
        }
    }

    void RotateUp()
    {
        transform.Rotate(1, 0, 0);
    }
    void RotateDown()
    {
        transform.Rotate(-1, 0, 0);
    }

}
