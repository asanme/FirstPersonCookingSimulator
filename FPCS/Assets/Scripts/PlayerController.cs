using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float x;
    private float z;

    [SerializeField] private CharacterController controller;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private float airResistance = 0.9f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float speed = 12f;
    
    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        Vector3 direction = transform.right * x + transform.forward * z;
        controller.Move(direction * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    } 
}
