using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    private PlayerInputs input;
    private Rigidbody rb;
    private void Awake()
    {
        input = new PlayerInputs();
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        input.Enable();
        input.Player.Walk.performed += OnMove;
        input.Player.Walk.started += OnMove;
        input.Player.Walk.canceled += OnMove;
    }
    private void OnDisable()
    {
        input.Disable();
        input.Player.Walk.performed -= OnMove;
        input.Player.Walk.started -= OnMove;
        input.Player.Walk.canceled -= OnMove;
    }
    private void OnMove(InputAction.CallbackContext context)
    {
        Vector3 movementDirection = context.ReadValue<Vector2>();
        /*if(movementDirection.y != 0f)
        {
            rb.velocity = transform.forward * movementDirection.y *speed;
        }
        if(movementDirection.x != 0f)
        {
            rb.velocity = transform.right * movementDirection.x * speed;
        }*/
        if(movementDirection == Vector3.zero)
        {
            rb.velocity = Vector3.zero;
        }
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = transform.forward * speed * (-1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = transform.right * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = transform.right * speed * (-1);
        }
    }
}
    
