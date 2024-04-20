using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Transform panelRecipes;
    public Transform panelIngredients;
    public Transform panelNeedIngredients;
    public List<InventorySlot> Slots = new List<InventorySlot>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < panelRecipes.childCount; i++) 
        {
            if(panelRecipes.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                Slots.Add(panelRecipes.GetChild(i).GetComponent<InventorySlot>());
            }
        }
    }
}
