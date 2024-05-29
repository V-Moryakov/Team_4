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
    public void UnlockWeapon1()
    {
        weapon1 = true;
    }
    public void UnlockWeapon2()
    {
        weapon2 = true;
        if(i==0)
        {
            knight.SetActive(true);
            i++;
        }
        
    }
    public void UnlockWeapon3()
    {
        weapon3 = true;
    }

}
