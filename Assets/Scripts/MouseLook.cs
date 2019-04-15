using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float lookSpeed = 3;
    public Camera playerCamera;
    private float verticalClamp = 20.0f;
    private Vector2 rotation = Vector2.zero;

    // Update is called once per frame
    void Update()
    {
        rotation.x += -Input.GetAxis("Mouse Y");
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x = Mathf.Clamp(rotation.x, -verticalClamp, verticalClamp);
        transform.eulerAngles = new Vector2(0, rotation.y) * lookSpeed;
        playerCamera.transform.localRotation = Quaternion.Euler(rotation.x * lookSpeed, 0, 0);
    }
}
