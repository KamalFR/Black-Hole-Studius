using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTrigger : MonoBehaviour
{
    public float distance;
    public bool isTask;
    public Transform playerCamera;
    public GameObject objToDestroy;
    public GameObject canvas;

    [Header("IGNORAR CASO NÃO SEJA  O TERMINAL!!!")]
    public GameObject terminal;
    public string menuTag;

    private void Update()
    {
        if (Physics.Raycast(playerCamera.position, EngineAmount.instance.transform.TransformDirection(Vector3.forward), out RaycastHit hit, distance))
        {
            if (hit.collider.tag == menuTag && (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.E)) && !isTask)
            {
                terminal.SetActive(true);
            }

            if ((hit.collider.tag == "LinesPainel") && (GameManager.instance.GetTeste()) && ((Input.GetKeyDown(KeyCode.Mouse0)) || Input.GetKeyDown(KeyCode.E)))
            {
                hit.collider.GetComponent<MenuTrigger>().canvas.SetActive(true);
                objToDestroy.SetActive(false);
            }
            if ((hit.collider.tag == "TimeKill") && (GameManager.instance._taskOxigenToDo) && ((Input.GetKeyDown(KeyCode.Mouse0)) || (Input.GetKeyDown(KeyCode.E))))
            {
                hit.collider.GetComponent<MenuTrigger>().canvas.SetActive(true);
            }
        }
    }
}