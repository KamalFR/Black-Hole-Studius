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

    [Header("Guinho")]
    public List<GameObject> menus;
    public Animator myAnimator;

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
        if (movementDirection == Vector3.zero)
        {
            rb.velocity = Vector3.zero;
        }
    }
    private void Update()
    {
        for (int i = 0; i < menus.Count; i++)
            if (menus[i].activeInHierarchy == true)
            {
                Cursor.visible = true;
                return;
            }

        Cursor.visible = false;

        Vector3 movementDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) movementDirection += transform.forward;
        if (Input.GetKey(KeyCode.S)) movementDirection -= transform.forward;
        if (Input.GetKey(KeyCode.D)) movementDirection += transform.right;
        if (Input.GetKey(KeyCode.A)) movementDirection -= transform.right;

        if (movementDirection != Vector3.zero)
        {
            movementDirection.Normalize();
            rb.velocity = movementDirection * speed;
            myAnimator.speed = 1;
        }
        else
        {
            rb.velocity = Vector3.zero;
            myAnimator.speed = 0;
        }
    }
}