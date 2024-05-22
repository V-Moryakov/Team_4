using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{

    float hp = 100;

    private void Update()
    {
        if (hp < 0)
            EnemyDie();
    }

    public void DealDamage(float damage)
    {
        hp -= damage;
    }

    void EnemyDie()
    {
        Destroy(gameObject);
        FindObjectOfType<PlayerExpiriance>().gameObject.GetComponent<PlayerExpiriance>().xp += 10;
    }

}
