using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesligarCanvas : MonoBehaviour
{
    public Canvas canvas;

    public void Toggle()
    {
        canvas.gameObject.SetActive(!canvas.gameObject.activeSelf);
    }
}

