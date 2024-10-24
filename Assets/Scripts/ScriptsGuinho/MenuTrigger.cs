using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTrigger : MonoBehaviour
{
    public string playerTag;
    public KeyCode menuButton;
    public GameObject menu;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Stay");
        if (other.tag == playerTag && Input.GetKeyDown(menuButton) && menu.activeInHierarchy == false) menu.SetActive(true);
    }
}
