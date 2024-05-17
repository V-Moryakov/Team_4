using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Attack : MonoBehaviour
{

    public float damage = 20;
    GameObject Player;

    private void Start()
    {
        Player = FindObjectOfType<PlayerController>().gameObject;
    }


    public void AttackEnemy1()
    {
        Invoke("AttackOnPlayer", 2);
    }
    void AttackOnPlayer()
    {
        Player.GetComponent<PlayerHealth>().DealDamage(damage);
        CancelInvoke("AttackOnPlayer");
    }

}
