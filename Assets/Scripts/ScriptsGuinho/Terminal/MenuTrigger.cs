using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTrigger : MonoBehaviour
{
    public string playerTag;
    public KeyCode terminalButton;
    public GameObject terminal;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == playerTag && Input.GetKeyDown(terminalButton) && terminal.activeInHierarchy == false) terminal.SetActive(true);
    }
}
