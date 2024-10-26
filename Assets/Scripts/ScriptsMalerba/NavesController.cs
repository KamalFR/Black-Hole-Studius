using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavesController : MonoBehaviour
{
    public float moveSpeed; // movimento
    public float rotationSpeed; // rotação
    [HideInInspector] public Vector3 movediraction;
    [HideInInspector] public bool isRotating;

    void FixedUpdate() // Update que é fixado entre FPS, não é afetado se o PC é batata ou nave espacial
    {
        // verifica se o player se movimentou e qual a direção
        if(!isRotating){
            transform.Translate(movediraction * moveSpeed * Time.deltaTime);
        }
        else{
           transform.Rotate(movediraction * rotationSpeed * Time.deltaTime);
        }
    }

    //UPDATE PARA QUANDO ESTIVER NO CENÁRIO
    // void Update()
    // {
    //     // Movimenta a nave para frente (tecla W e S)
    //     if (Input.GetKey(KeyCode.W))
    //     {
    //         isRotating = false;
    //         movediraction = Vector3.up;
    //     }
    //     else if (Input.GetKey(KeyCode.S))
    //     {
    //         isRotating = false;
    //         movediraction = Vector3.down;
    //     }
    //     // Rotaciona a nave (A ou D)
    //     else if (Input.GetKey(KeyCode.A))
    //     {
    //         isRotating = true;
    //         movediraction = Vector3.forward;
    //     }
    //     else if (Input.GetKey(KeyCode.D))
    //     {
    //         isRotating = true;
    //         movediraction = -Vector3.forward;
    //     }
    //     // se o Player nao apertar nada
    //     else{
    //         isRotating = false;
    //         movediraction = Vector3.zero;
    //     }
    // }
}
