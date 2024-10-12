using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarInterfaces : MonoBehaviour
{
    [SerializeField] private GameObject[] ativar;
    private GameObject player;
    private int tamanho;
    private bool canActive;
    private void Start()
    {
    
        tamanho = ativar.Length;
        for (int i = 0; i < tamanho; i++)
        {
            ativar[i].gameObject.SetActive(false);
        }
        canActive = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canActive = true;
            player = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canActive = false;
        }
    }
    private void Update()
    {
        if (canActive)
        {
            if (Input.GetKey(KeyCode.E))
            {
                for (int i = 0; i < tamanho; i++)
                {
                    ativar[i].gameObject.SetActive(true);                
                }
                player.GetComponent<PlayerMovement>().enabled = false;
                player.GetComponent<CameraRotate>().enabled = false;
                Cursor.visible = true;
            }
        }
    }
}
