using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotsIngredientList : MonoBehaviour
{
    public GameObject[] Slots;
    private void Update()
    {
        CheckItemInSlots();
    }

    void CheckItemInSlots()
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            if (Slots[i].transform.Find("Button").gameObject.active)
                Slots[i].gameObject.name = "SlotsFull";
            else
                Slots[i].gameObject.name = "Slot";
        }
    }

    public void AddItem(GameObject drop)
    {
        var b = true;
        for (int i = 0; i < Slots.Length; i++)
        {
            if (Slots[i].name == "Slot" && b == true)
            {
                Debug.Log("1");
                Slots[i].name = "SlotFull";
                b = false;
                Slots[i].transform.Find("Button").gameObject.SetActive(true);
                Slots[i].transform.Find("Button").gameObject.GetComponent<Image>().sprite = drop.transform.Find("Button").GetComponent<Image>().sprite;
                Slots[i].transform.Find("Button").Find("ElementName").gameObject.GetComponent<TextMeshProUGUI>().text = drop.transform.Find("ElementName").GetComponent<TextMeshProUGUI>().text;
            }
        }
    }

}
