using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTrigger : MonoBehaviour
{
    public string menuTag;
    public float distance;
    public bool isTask;
    public Transform playerCamera;
    public GameObject objToDestroy;
    public GameObject menu;

    private void Update()
    {
        if (Physics.Raycast(playerCamera.position, EngineAmount.instance.transform.TransformDirection(Vector3.forward), out RaycastHit hit, distance))
        {
            if (hit.collider.tag == menuTag && (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.E)) && !isTask)
            {
                menu.SetActive(true);
            }

            if (hit.collider.tag == menuTag && (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.E)) && isTask && GameManager.instance._startLineTask)
            {
                menu.SetActive(true);
                objToDestroy.SetActive(false);
            }
        }
    }
}
