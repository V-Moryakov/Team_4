using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHP : MonoBehaviour
{

    public float hp = 100;
    public Animator animator;
    bool isDie = false;
    private void Update()
    {
        if (hp < 0 && !isDie)
            EnemyDie();

    }

    public void DealDamage(float damage)
    {
        hp -= damage;
        animator.SetTrigger("hit");
    }

    void EnemyDie()
    {
        isDie = true;
        Invoke("DestroyObj", 3.33f);
        animator.SetTrigger("death");
        GetComponent<EnemyPatrol>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        FindObjectOfType<PlayerExpiriance>().gameObject.GetComponent<PlayerExpiriance>().xp += 10;
    }
    void DestroyObj()
    {
        Destroy(gameObject);
    }
}
