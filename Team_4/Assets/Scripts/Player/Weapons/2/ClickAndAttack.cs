﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndAttack : MonoBehaviour
{

    public GameObject Laser;

    private void Update()
    {
        SearchEnemyAndAttack();
    }

    void SearchEnemyAndAttack()
    {
        var diracton = gameObject.transform.forward;
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, diracton, out hit))
        {
            if (hit.collider.CompareTag("Enemy") && Input.GetMouseButtonDown(0))
            {
                Attack(hit.collider.transform);
            }
        }
    }

    void Attack(Transform point)
    {
        Instantiate(Laser, point.position, new Quaternion(0,0,0,0));
    }
}