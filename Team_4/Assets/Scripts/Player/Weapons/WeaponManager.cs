using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && gameObject.GetComponent<WeaponUnlock>().weapon1 == true)
        {
            if(gameObject.GetComponent<FireOnClick>().enabled == false)
                gameObject.GetComponent<FireOnClick>().enabled = true;
            else
                gameObject.GetComponent<FireOnClick>().enabled = false;
        }
    }

}
