using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{

    GameObject player;
    public GameObject patron;
    public float timeAttack;
    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>().gameObject;
    }

    private void Update()
    {

        SearchPlayer();
    }


    void SearchPlayer()
    {
        var diraction = transform.forward;

        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position + Vector3.up, diraction, out hit))
        {
            if (hit.collider.GetComponent<PlayerHealth>() != null)
            {
                Debug.Log("2");
                Invoke("Attack",timeAttack);
            }
            else
            {
                Debug.Log("1");
                gameObject.transform.Rotate(0,10,0);
            }
        }

    }


    void Attack()
    {
        Instantiate(patron, transform.position, transform.rotation);
        CancelInvoke();
    }

}
