using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExpiriance : MonoBehaviour
{
    public List<Level> levels;
    public RectTransform xpBar;
    public float xp, xpNeed;
    public int level=1;

    private void Update()
    {
        DrawUI();
        if(xp >= xpNeed)
        {
            lvlUp();
        }
    }




    public void lvlUp()
    {
        level += 1;
        xp = 0;
        xpNeed = levels[level-1].xpNeed;
        gameObject.GetComponent<PlayerHealth>().maxHealth = levels[level - 1].hpMax;
        gameObject.GetComponent<PlayerHealth>().health = levels[level - 1].hpMax * (gameObject.GetComponent<PlayerHealth>().health/ levels[level - 2].hpMax);

    }

    public void DrawUI()
    {
        xpBar.anchorMax = new Vector2(xp / xpNeed,1);
    }
}
