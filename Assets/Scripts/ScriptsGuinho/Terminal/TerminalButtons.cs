using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalButtons : MonoBehaviour
{
    public void ShowObj(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void HideObj(GameObject obj)
    {
        obj.SetActive(false);
    }
}
