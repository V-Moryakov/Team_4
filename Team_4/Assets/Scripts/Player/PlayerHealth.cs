using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float health;
    public float maxHealth;
    public RectTransform HPBar;
    public Animator animator;
    private void Start()
    {
        maxHealth = health;
    }

    private void Update()
    {
        //HPBarUpdate();
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            PlayerIsDead();
        }
        HPBarUpdate();
    }

    private void PlayerIsDead()
    {
        animator.SetTrigger("death");
    }
    public void HPBarUpdate()
    {
        HPBar.anchorMax = new Vector2(health/maxHealth,1);
    }
}
