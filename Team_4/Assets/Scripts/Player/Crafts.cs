using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Crafts : MonoBehaviour
{

    public string CraftText;
    public GameObject Slot1, Slot2, Slot3;

    public void Craft()
    {
        var s1 = Slot1.transform.Find("Button").Find("ElementName").GetComponent<TextMeshProUGUI>().text;
        var s2 = Slot2.transform.Find("Button").Find("ElementName").GetComponent<TextMeshProUGUI>().text;
        var s3 = Slot3.transform.Find("Button").Find("ElementName").GetComponent<TextMeshProUGUI>().text;
        if(s1 != "" && s2 != "" && s3 == "")
            CraftText = s1 + s2;
        if (s1 != "" && s2 == "" && s3 != "")
            CraftText = s1 + s3;
        if (s1 == "" && s2 != "" && s3 != "")
            CraftText = s2 + s3;
        if (s1 != "" && s2 != "" && s3 != "")
            CraftText = s1 + s2 + s3;
        if (s1 != "" && s2 == "" && s3 == "")
            CraftText = s1;
        if (s1 == "" && s2 != "" && s3 == "")
            CraftText = s2;
        if (s1 == "" && s2 == "" && s3 != "")
            CraftText = s3;
        if (s1 == "" && s2 == "" && s3 == "")
            CraftText = "";
        Debug.Log(CraftText);
        Result();
    }

    void Result()
    {
        if(CraftText == "FlowerMushroom" || CraftText == "MushroomFlower")
        {
            gameObject.GetComponent<WeaponUnlock>().UnlockWeapon1();
            ClearSlots();
        }
        if (CraftText == "SkullCristalFlower" || CraftText == "SkullFlowerCristal" || CraftText == "CristalSkullFlower" || CraftText == "CristalFlowerSkull" || CraftText == "FlowerSkullCristal" || CraftText == "FlowerCristalSkull")
        {
            if(gameObject.GetComponent<PlayerExpiriance>().level >= 2)
            {
                gameObject.GetComponent<WeaponUnlock>().UnlockWeapon2();
                ClearSlots();
            }
        }
    }

    void ClearSlots()
    {
        Slot1.transform.Find("Button").gameObject.SetActive(false);
        Slot2.transform.Find("Button").gameObject.SetActive(false);
        Slot3.transform.Find("Button").gameObject.SetActive(false);
    }

}
