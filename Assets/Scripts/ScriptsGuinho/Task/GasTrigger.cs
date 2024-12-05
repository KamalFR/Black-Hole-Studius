using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GasTrigger : MonoBehaviour
{
    public Transform playerCamera;
    public GameObject gasTask;

    [SerializeField] private GameObject _warningTask;

    public void Start()
    {
        _warningTask.SetActive(false);
    }

    private void Update()
    {
        if (!GameManager.instance._taskOxigenToDo)
        {
            if (_warningTask.activeSelf == true) _warningTask.SetActive(false);
            return;
        }

        if (Physics.Raycast(playerCamera.position, EngineAmount.instance.transform.TransformDirection(Vector3.forward), out RaycastHit hit, 3))
        {
            if (_warningTask.activeSelf == false) _warningTask.SetActive(true);

            if (hit.collider.tag == "TimeKill" && (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.E))) gasTask.SetActive(true);
        }
    }
}
