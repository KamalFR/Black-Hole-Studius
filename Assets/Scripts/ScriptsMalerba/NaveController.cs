using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveController : MonoBehaviour
{
    public float moveSpeed = 100f; // movimento
    public float rotationSpeed = 200f; // rotação

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");                                                  // A/D ou Setas Esquerda/Direita ou Joystick
        float moveVertical = Input.GetAxisRaw("Vertical");                                                      // W/S ou Setas Cima/Baixo ou Joystick

        Vector3 moveDirection = new Vector3(moveHorizontal, moveVertical, 0f);
        
        transform.Translate(moveDirection * moveSpeed);
        
    }
}
