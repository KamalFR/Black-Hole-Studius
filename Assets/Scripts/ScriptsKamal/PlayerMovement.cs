using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private PlayerInputs input;
    private Rigidbody rb;

    [Header("Guinho")]
    public List<GameObject> menus;
    public Animator myAnimator;

    [SerializeField] private float _maxStamina;
    [SerializeField] private float _currentStamina;
    private bool _isTired;

    [SerializeField] private Slider _staminaSlider;

    private void Awake()
    {

        input = new PlayerInputs();
        rb = GetComponent<Rigidbody>();
        _isTired = false;
    }

    void Start()
    {
        _currentStamina = _maxStamina;
        _staminaSlider.maxValue = _maxStamina;
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
    private void FixedUpdate()
    {
        for (int i = 0; i < menus.Count; i++)
            if (menus[i].activeInHierarchy == true)
            {
                Cursor.visible = true;
                return;
            }

        Cursor.visible = false;
        // Correr (aumenta a velocidade do player)]
        float currentSpeed;
        if (_isTired)
        {
            if (_currentStamina < _maxStamina)
            {
                _currentStamina += Time.deltaTime;
            }
            else
            {
                _isTired = false;
            }
            currentSpeed = .5f;
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (_currentStamina > 0)
                {
                    currentSpeed = 1.5f;
                    _currentStamina -= Time.deltaTime;
                }
                else
                {
                    if (_currentStamina < _maxStamina)
                    {
                        _currentStamina += Time.deltaTime;
                    }
                    else
                    {
                        _isTired = false;
                    }
                    currentSpeed = .5f;
                    _isTired = true;
                }
            }
            else
            {
                currentSpeed = 1;
                if (_currentStamina < _maxStamina)
                {
                    _currentStamina += Time.deltaTime;
                }
                else
                {
                    _isTired = false;
                }
            }
        }

        _staminaSlider.value = _currentStamina;


        // Cansa por um tempo cooldown


        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        float mouseAxis = Input.GetAxis("Mouse X");

        Vector3 movementDirection = transform.right * horizontalMovement + transform.forward * verticalMovement;

        if (movementDirection.magnitude > 0)
        {
            myAnimator.speed = 1;
        }
        else
        {
            myAnimator.speed = 0;
        }

        rb.velocity = movementDirection.normalized * (speed * currentSpeed);
        transform.Rotate(0, mouseAxis, 0);



    }
}

