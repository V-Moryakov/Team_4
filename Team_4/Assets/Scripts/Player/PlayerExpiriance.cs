using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerExpiriance : MonoBehaviour
{
    public List<Level> levels;
    public RectTransform xpBar;
    public float xp, xpNeed;
    public int level=1;
    public TextMeshProUGUI lvlText;
    bool lvlMax = false;

    private void Start()
    {
        level = PlayerPrefs.GetInt("level");
        GetLevel();
    }


    private void Update()
    {
        DrawUI();
        if (!lvlMax)
        { 
            if (levels.Count > level)
            {
                if (xp >= xpNeed)
                {
                    lvlUp();
                }
            }
            else
            {
                lvlText.text = level.ToString();
                xp = xpNeed;
                lvlMax = true;
            }
        }
    }




    public void lvlUp()
    {

            level += 1;
            xp = 0;
            xpNeed = levels[level-1].xpNeed;
            gameObject.GetComponent<PlayerHealth>().maxHealth = levels[level - 1].hpMax;
            gameObject.GetComponent<PlayerHealth>().health = levels[level - 1].hpMax * (gameObject.GetComponent<PlayerHealth>().health/ levels[level - 2].hpMax);
            lvlText.text = level.ToString();
            PlayerPrefs.SetInt("level", level);
    }

    public void GetLevel()
    {
        xpNeed = levels[level - 1].xpNeed;
        gameObject.GetComponent<PlayerHealth>().maxHealth = levels[level - 1].hpMax;
        gameObject.GetComponent<PlayerHealth>().health = levels[level - 1].hpMax * (gameObject.GetComponent<PlayerHealth>().health / levels[level - 2].hpMax);
        lvlText.text = level.ToString();
        DrawUI();
    }

    public void DrawUI()
    {
        xpBar.anchorMax = new Vector2(xp / xpNeed,1);
    }
}
