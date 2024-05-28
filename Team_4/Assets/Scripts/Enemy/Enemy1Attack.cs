using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Attack : MonoBehaviour
{

    public float damage = 20;
    GameObject Player;
    public Animator animator;
    bool WaitAttack = false;
    private void Start()
    {
        WaitAttack = false;
        Player = FindObjectOfType<PlayerController>().gameObject;
    }


    public void AttackEnemy1()
    {
        
        Invoke("AttackOnPlayer", 2);
 
            
    }
    void AttackOnPlayer()
    {
        CancelInvoke("AttackOnPlayer");
        animator.SetTrigger("attack");
        Player.GetComponent<PlayerHealth>().DealDamage(damage);
    }

}
