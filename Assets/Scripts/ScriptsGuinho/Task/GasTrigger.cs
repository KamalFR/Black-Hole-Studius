using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasTrigger : MonoBehaviour
{
    public Transform playerCamera;
    public GameObject gasTask;

    private void Update()
    {
        if (!GameManager.instance._taskOxigenToDo) return;

        if (Physics.Raycast(playerCamera.position, EngineAmount.instance.transform.TransformDirection(Vector3.forward), out RaycastHit hit, 3))
        {
            if((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.E))) gasTask.SetActive(true);
        }
    }
}
