using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

[CreateAssetMenu(fileName = "IngredientItem", menuName = "Inventory/Item/New ingredient item")]
public class IngredientItem : ItemScriptableObject
{
    private void Start()
    {
        itemTipe = ItemTipe.Ingredients;
    }
}
