using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveIngredients : MonoBehaviour
{
    private void Start()
    {
    }

    private void Update()
    {
        Fail();
    }

    
    public void Move()
    {
 
            Debug.Log('!');
            gameObject.transform.position = Input.mousePosition;
        
    }
    
    
    void Fail()
    {
        var diraction = Camera.main.ScreenPointToRay(Input.mousePosition); ;
        RaycastHit hit;
        if(Physics.Raycast(diraction, out hit))
        {
            if(hit.collider.GetComponent<Image>() != null)
            {
                Debug.Log(hit.collider.name);
            }
        }
    }

}
