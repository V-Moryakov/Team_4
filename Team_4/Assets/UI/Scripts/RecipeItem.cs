using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeItem", menuName = "Inventory/Item/New recipe item")]
public class RecipeItem : ItemScriptableObject
{
    // Start is called before the first frame update
    void Start()
    {
        itemTipe = ItemTipe.Recipes;
    }
}
