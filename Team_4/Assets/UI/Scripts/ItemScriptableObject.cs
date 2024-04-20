using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTipe {Ingredients, Recipes}
public class ItemScriptableObject : ScriptableObject
{
    public ItemTipe itemTipe;
    public string itemName;
    public string itemDescription;
    public int maxAmount;
}
