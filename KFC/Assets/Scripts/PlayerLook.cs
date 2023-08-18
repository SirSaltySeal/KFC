/*
 * Author: Tanucan Cliford Baguio
 * Date: 24/07/2023
 * Description: Player Look
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;
    
    Camera cam;

    float mouseX;
    float mouseY;

    float multiplier = 0.01f;

    float xRotation;
    float yRotation;

    private void Start()
    {
        cam = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        myInput();
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    void myInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        yRotation += mouseX * sensX * multiplier ; //look horizontally
        xRotation -= mouseY * sensY * multiplier ; //look vertically & subtract to prevent inversion when looking

        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //Player does not look too far back vertically
    }
}
