using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTrigger : MonoBehaviour
{
    public float distance;
    public bool isTask;
    public Transform playerCamera;
    [SerializeField] private GameObject _warningTask;

    [Header("IGNORAR CASO N�O SEJA  O TERMINAL!!!")]
    public GameObject terminal;
    public string menuTag;

    public void Start()
    {
        if (isTask) _warningTask?.SetActive(false);
    }

    private void Update()
    {
        if (isTask)
        {
            if (gameObject.tag == "LinesPainel" + GameManager.instance._indexLineTask)
            {
                if (_warningTask?.activeSelf == false) _warningTask?.SetActive(true);
            }
            else
            {
                if (_warningTask?.activeSelf == true) _warningTask?.SetActive(false);
            }
        }

        if (Physics.Raycast(playerCamera.position, EngineAmount.instance.transform.TransformDirection(Vector3.forward), out RaycastHit hit, distance))
        {
            if (hit.collider.tag == menuTag && (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.E)) && !isTask)
            {
                terminal.SetActive(true);
            }

            if (hit.collider.tag == "LinesPainel" + GameManager.instance._indexLineTask && (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.E)) && isTask)
            {
                GameManager.instance.linesTasks[GameManager.instance._indexLineTask].SetActive(true);
            }
        }
    }
}
