/*
 * Author: Tanucan Cliford Baguio
 * Date: 24/07/2023
 * Description: Player Movement
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f;
    float movementMultiplier = 10f;
    float sprintMultiplier = 20f;
    float rbDrag = 6f;
    float horizontalMovement;
    float verticalMovement;
    Vector3 moveDirection;
    Rigidbody rb;
    public bool isMoving = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; //rigid body does not rotate when hitting another game object
    }

    private void Update()
    {
        myInput();
        ControlDrag();
      
    }

    void myInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        isMoving = true;
        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement; //move in direction relative to where player is looking
    }

    void ControlDrag()
    {
        rb.drag = rbDrag;
    }

    private void FixedUpdate()
    {
        MovePlayer();
        SprintPlayer();
    }

    void MovePlayer()
    {
        rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier , ForceMode.Acceleration); //move speed remain constant when W + A/ W + D etc. keys are pressed
    }

    void SprintPlayer()
    {
        if (Input.GetKey(KeyCode.LeftShift) & isMoving == true)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * sprintMultiplier, ForceMode.Acceleration); 
        }
    }
}
