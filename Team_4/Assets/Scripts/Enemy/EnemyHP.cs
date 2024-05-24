using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHP : MonoBehaviour
{

    float hp = 100;
    public Animator animator;

    private void Update()
    {
        if (hp < 0)
            EnemyDie();

    }

    public void DealDamage(float damage)
    {
        hp -= damage;
        animator.SetTrigger("hit");
    }

    void EnemyDie()
    {
        animator.SetTrigger("death");
        GetComponent<EnemyPatrol>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        // Destroy(gameObject);
        FindObjectOfType<PlayerExpiriance>().gameObject.GetComponent<PlayerExpiriance>().xp += 10;
    }
}
