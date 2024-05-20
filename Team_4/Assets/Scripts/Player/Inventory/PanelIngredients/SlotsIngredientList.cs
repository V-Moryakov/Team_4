using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsIngredientList : MonoBehaviour
{
    public GameObject[] Slots;
    private void Start()
    {
        Debug.Log(Slots[0].transform.position);
    }
}
