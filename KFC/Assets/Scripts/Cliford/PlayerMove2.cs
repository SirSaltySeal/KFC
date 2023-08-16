/*
 * Author: Tanucan Cliford Baguio
 * Date: 24/07/2023
 * Description: Player Movement
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMove2 : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f;
    float movementMultiplier = 10f;
    float sprintMultiplier = 12f;
    float rbDrag = 6f;
    float horizontalMovement;
    float verticalMovement;
    Vector3 moveDirection;
    Rigidbody rb;
    public bool isMoving = false;
    public TextMeshProUGUI killCounter;
    Target script;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; //rigid body does not rotate when hitting another game object
        script = FindObjectOfType<Target>();
    }

    private void Update()
    {
        myInput();
        ControlDrag();
        killCounter.text = "Kill All Enemies";
        if(script.score == 1 )
        {
            Destroy(gameObject);
        }
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
        rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration); //move speed remain constant when W + A/ W + D etc. keys are pressed
    }

    void SprintPlayer()
    {
        if (Input.GetKey(KeyCode.LeftShift) & isMoving == true)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * sprintMultiplier, ForceMode.Acceleration);
        }
    }
}
