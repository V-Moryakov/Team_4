using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public bool ItemTrue;

    private void Update()
    {
        SearchItem();
    }

    void SearchItem()
    {
        var diraction = gameObject.transform.forward;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, diraction, out hit))
        {
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("Item"))
                {
                    if ( hit.distance < 3)
                    {
                        ItemTrue = true;
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else
                        ItemTrue = false;
                }
                else
                    ItemTrue = false;
            }
        }
    }

}
