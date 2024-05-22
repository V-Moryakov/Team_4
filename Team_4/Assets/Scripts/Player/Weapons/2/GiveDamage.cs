using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDamage : MonoBehaviour
{
    public float damage = 1f;
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.GetComponent<EnemyHP>() != null)
        {
            other.GetComponent<EnemyHP>().DealDamage(damage/10);
        }
    }

}
