using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehave : MonoBehaviour
{/*
    private NavesController naveController;
    public bool canActive;
    // Start is called before the first frame update
    void Start()
    {
        naveController = GameObject.FindWithTag("Nave").GetComponent<NavesController>();
        Debug.Log(naveController);
    }
    //pode ativar o objeto
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canActive = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            naveController.isRotating = false;
            naveController.movediraction = Vector3.zero;
            canActive = false;
        }
    }
    //ao ativar o objeto
    void Update()
    {
        if (canActive)
        {
            if (Input.GetKey(KeyCode.E))
            {
                if(gameObject.CompareTag("esquerda")){
                    naveController.isRotating = true;
                    naveController.movediraction = -Vector3.forward;
                    Debug.Log("esquerda");
                }else if(gameObject.CompareTag("direita")){
                    naveController.isRotating = true;
                    naveController.movediraction = Vector3.forward;
                    Debug.Log("direita");
                }
                else if(gameObject.CompareTag("cima")){
                    naveController.isRotating = false;
                    naveController.movediraction = Vector3.up;
                    Debug.Log("cima");
                }else if(gameObject.CompareTag("baixo")){
                    naveController.isRotating = false;
                    naveController.movediraction = Vector3.down;
                    Debug.Log("baixo");
                }
            }else{
                naveController.isRotating = false;
                naveController.movediraction = Vector3.zero;
            }
        }
    }*/
}
