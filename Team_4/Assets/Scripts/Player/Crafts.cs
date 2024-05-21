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
        var s1 = Slot1.transform.Find("Button").gameObject.transform.Find("ElementName").GetComponent<TextMeshProUGUI>().text;
        var s2 = Slot2.transform.Find("Button").Find("ElementName").GetComponent<TextMeshProUGUI>().text;
        var s3 = Slot3.transform.Find("Button").Find("ElementName").GetComponent<TextMeshProUGUI>().text;
        if(s1 != "" && s2 != "" && s3 == "")
            CraftText = s1 + s2;
        if (s1 != "" && s2 == "" && s3 != "")
            CraftText = s1 + s3;
        if (s1 == "" && s2 != "" && s3 != "")
            CraftText = s2 + s3;
        Debug.Log(CraftText);
        Result();
    }

    void Result()
    {
        if(CraftText == "FlowerMashroom" || CraftText == "MashroomFlower")
        {
            gameObject.GetComponent<WeaponUnlock>().UnlockWeapon1();
            ClearSlots();
        }
    }

    void ClearSlots()
    {
        Slot1.transform.Find("Button").gameObject.SetActive(false);
        Slot2.transform.Find("Button").gameObject.SetActive(false);
        Slot3.transform.Find("Button").gameObject.SetActive(false);
    }

}
