using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject Tips;
    public bool ItemTrue;
    public SlotsIngredientList PanelIngredients;

    private void Update()
    {
        SearchItem();
    }

    void SearchItem()
    {
        var diraction = gameObject.transform.forward;
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, diraction, out hit))
        {
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("Item"))
                {
                    if ( hit.distance < 3)
                    {
                        Tips.SetActive(true);
                        ItemTrue = true;
                        Podbor(hit);
                    }
                    else
                    {
                        Tips.SetActive(false);
                        ItemTrue = false;
                    }
                        
                }
                else
                {
                    Tips.SetActive(false);
                    ItemTrue = false;
                }
            }
        }
    }

    void Podbor(RaycastHit hit1)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(hit1.collider.gameObject);
            PanelIngredients.AddItem(hit1.collider.gameObject);
            Tips.SetActive(false);
        }
    }
}
