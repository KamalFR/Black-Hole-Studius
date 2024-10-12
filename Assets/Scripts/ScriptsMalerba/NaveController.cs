using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveController : MonoBehaviour
{
    public float moveSpeed = 100f; // movimento
    public float rotationSpeed = 200f; // rotação
    public Vector3 movediraction;
    public bool isRotating;

    void FixedUpdate() // Update que é fixado entre FPS, não é afetado se o PC é batata ou nave espacial
    {
        // verifica se o player se movimentou e qual a direção
        if(!isRotating){
            Debug.Log("Abuble");
            transform.Translate(movediraction * moveSpeed);
        }
        else{
            Debug.Log("Abuble");
           transform.Rotate(movediraction * rotationSpeed);
        }
    }
    void Update()
    {
        // Movimenta a nave para frente (tecla W e S)
        if (Input.GetKey(KeyCode.W))
        {
            isRotating = false;
            movediraction = Vector3.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            isRotating = false;
            movediraction = Vector3.down;
        }
        // Rotaciona a nave (A ou D)
        else if (Input.GetKey(KeyCode.A))
        {
            isRotating = true;
            movediraction = Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            isRotating = true;
            movediraction = -Vector3.forward;
        }
        // se o Player nao apertar nada
        else{
            isRotating = false;
            movediraction = Vector3.zero;
        }
    }
}
