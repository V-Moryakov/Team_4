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
            {
                gameObject.GetComponent<FireOnClick>().enabled = true;
                gameObject.GetComponent<ClickAndAttack>().enabled = false;
            }
                
            else
                gameObject.GetComponent<FireOnClick>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && gameObject.GetComponent<WeaponUnlock>().weapon2 == true)
        {
            if (gameObject.GetComponent<ClickAndAttack>().enabled == false)
            {
                gameObject.GetComponent<ClickAndAttack>().enabled = true;
                gameObject.GetComponent<FireOnClick>().enabled = false;
            }

            else
                gameObject.GetComponent<ClickAndAttack>().enabled = false;
        }
    }

}
