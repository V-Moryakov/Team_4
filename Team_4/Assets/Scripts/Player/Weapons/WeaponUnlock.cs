using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUnlock : MonoBehaviour
{


    public bool weapon1 = false;
    public bool weapon2 = false;
    public bool weapon3 = false;
    public GameObject knight;
    int i = 0;

    private void Start()
    {
        int q = PlayerPrefs.GetInt("weapon1");
        if (q == 2)
            weapon1 = true;
        int w = PlayerPrefs.GetInt("weapon2");
        if (w == 2)
            weapon2 = true;
    }

    public void UnlockWeapon1()
    {
        weapon1 = true;
        PlayerPrefs.SetInt("weapon1", 2);
    }
    public void UnlockWeapon2()
    {
        weapon2 = true;
        if(i==0)
        {
            knight.SetActive(true);
            i++;
        }
        PlayerPrefs.SetInt("weapon2", 2);
    }
    public void UnlockWeapon3()
    {
        weapon3 = true;
    }

}
