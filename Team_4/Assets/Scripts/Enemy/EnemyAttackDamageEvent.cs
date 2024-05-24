using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackDamageEvent : MonoBehaviour
{
    public Enemy1Attack enemy1Attack;
    public void AttackDamageEvent()
    {
        enemy1Attack.AttackEnemy1();
    }
}
