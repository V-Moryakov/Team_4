using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{

    public RectTransform hp;
    public GameObject Win;

    private void Update()
    {
        DrawUI();
        if(gameObject.GetComponent<EnemyHP>().hp<= 0)
        {
            Win.SetActive(true);
        }
    }

    void DrawUI()
    {
        hp.anchorMax = new Vector2(gameObject.GetComponent<EnemyHP>().hp/ gameObject.GetComponent<EnemyHP>().maxhp, 1);
    }

}
