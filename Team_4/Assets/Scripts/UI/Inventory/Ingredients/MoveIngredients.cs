using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

public class MoveIngredients : MonoBehaviour
{
    public GameObject reserv;
    GameObject icon;

    private void Update()
    {

        RaycastUI();
    }


    void RaycastUI()
    {
        if (EventSystem.current.IsPointerOverGameObject() && EventSystem.current.currentSelectedGameObject.gameObject.CompareTag("inventoryItem"))
        {
            if (Input.GetMouseButton(0))
            {
                icon = EventSystem.current.currentSelectedGameObject;
                //Debug.Log(icon.name);
                EventSystem.current.currentSelectedGameObject.SetActive(false);
                reserv.SetActive(true);
                reserv.GetComponent<UnityEngine.UI.Image>().sprite = EventSystem.current.currentSelectedGameObject.GetComponent<UnityEngine.UI.Image>().sprite;
                reserv.transform.Find("ElementName").GetComponent<TextMeshProUGUI>().text = EventSystem.current.currentSelectedGameObject.transform.Find("ElementName").GetComponent<TextMeshProUGUI>().text;
                reserv.transform.position = Input.mousePosition;
                reserv.GetComponent<changeSlot>().smena = true;
            }
            else
            {
                //EventSystem.current.currentSelectedGameObject.SetActive(true);
                Invoke("ReservOff", 0.01f);
                EventSystem.current.currentSelectedGameObject.gameObject.transform.localPosition = new Vector3(0, 0, 0);
            }

        }
    } 


    public void IconSwitch(int i)
    {
        if(i == 1)
        {
            icon.SetActive(false);
            icon.transform.Find("ElementName").GetComponent<TextMeshProUGUI>().text = "";
        }
        else
            icon.SetActive(true);
    }

    public void Move()
    {

        Debug.Log('!');
        gameObject.transform.position = Input.mousePosition;

    }

    void ReservOff()
    {
        reserv.SetActive(false);
    }

}
