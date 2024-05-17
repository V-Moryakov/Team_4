using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float health;
    public float maxHealth;
    public RectTransform HPBar;
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
        HPBarUpdate();
    }
    public void HPBarUpdate()
    {
        HPBar.anchorMax = new Vector2(health/maxHealth,1);
    }
}
