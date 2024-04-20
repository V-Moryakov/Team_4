using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform CameraAxisTransform;
    
    private float minAngle;
    private float maxAngle;

    private float RotationSpeed = 500;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse X"), 0);

        var newAngleX = CameraAxisTransform.localEulerAngles.x - Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse Y");
        if(newAngleX > 180)
        {
            newAngleX -= 360;
        }

        newAngleX = Mathf.Clamp(newAngleX, minAngle, maxAngle);

        CameraAxisTransform.localEulerAngles = new Vector3(newAngleX, 0, 0);
    }
}
