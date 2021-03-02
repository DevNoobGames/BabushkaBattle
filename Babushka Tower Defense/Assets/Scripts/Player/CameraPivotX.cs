using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivotX : MonoBehaviour
{

    float rotationX = 0;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    void Update()
    {
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        //transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }
}
