using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class changeSlot : MonoBehaviour
{
    Collider2D slot;
    public GameObject Inventory;
    public bool smena;
    private void OnTriggerStay2D(Collider2D collision)
    {   
        if(collision.gameObject.CompareTag("Slot") && !collision.transform.Find("Button").gameObject.active) 
        {
            slot = collision;
            smena = true;
            //Debug.Log(collision.gameObject.transform.Find("Button").gameObject.name);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slot"))
        {
            slot = null;
        }
    }

    private void Update()
    {
        Debug.Log(slot == null);
        if(!Input.GetMouseButton(0) && slot == null && smena == true)
        {
            Inventory.GetComponent<MoveIngredients>().IconSwitch(0);
            Debug.Log("0");
            smena = false;
        }

        if (!Input.GetMouseButton(0) && slot != null && smena == true)
        {
            Debug.Log("1");
            Inventory.GetComponent<MoveIngredients>().IconSwitch(1);
            slot.gameObject.transform.Find("Button").gameObject.SetActive(true);
            slot.gameObject.transform.Find("Button").gameObject.GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
            slot.gameObject.transform.Find("Button").Find("ElementName").GetComponent<TextMeshProUGUI>().text = gameObject.transform.Find("ElementName").GetComponent<TextMeshProUGUI>().text;
            slot = null;
            smena = false;
        }
        

    }

}
