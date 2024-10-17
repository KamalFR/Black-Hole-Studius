using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ActiveButtons : MonoBehaviour
{
    [SerializeField] private float range = 10f;
    private NavesController naveController;
    void Start()
    {
        naveController = GameObject.FindWithTag("Nave").GetComponent<NavesController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit, range))
        {
            if(hit.collider.tag == "Botoes")
            {
                Debug.Log("fawhbiawfhbifb");
                if (Input.GetKey(KeyCode.E))
                {
                    if (hit.collider.gameObject.GetComponent<Button>().GetTipo() == EnumBotoes.Cima)
                    {
                        naveController.isRotating = false;
                        naveController.movediraction = Vector3.up;
                    }
                    if (hit.collider.gameObject.GetComponent<Button>().GetTipo() == EnumBotoes.Direita)
                    {
                        naveController.isRotating = true;
                        naveController.movediraction = Vector3.forward;
                    }
                    if (hit.collider.gameObject.GetComponent<Button>().GetTipo() == EnumBotoes.Baixo)
                    {
                        naveController.isRotating = false;
                        naveController.movediraction = Vector3.down;
                    }
                    if (hit.collider.gameObject.GetComponent<Button>().GetTipo() == EnumBotoes.Esquerda)
                    {
                        naveController.isRotating = true;
                        naveController.movediraction = -Vector3.forward;
                    }
                }
            }
            else
            {
                naveController.isRotating = false;
                naveController.movediraction = Vector3.zero;
            }
        }
    }
}
