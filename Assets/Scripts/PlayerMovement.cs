using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedH;
    public float speedV;

    float movementX;
    float movementY;

    private void Update()
    {
        //Rotation
        movementX += speedH * Input.GetAxis("Mouse X");
        movementY -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(movementY, movementX, 0);

        //Translation: Coming soon...
    }
}
