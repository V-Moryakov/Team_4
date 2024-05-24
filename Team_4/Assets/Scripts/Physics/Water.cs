using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            other.GetComponent<PlayerHealth>().DealDamage(10);
        }
    }

}
