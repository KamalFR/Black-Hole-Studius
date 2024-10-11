using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private float sensibilidade = 2f;
    private float mouseX, mouseY; 

    private void Start()
    {
        mouseX = 0f;
        mouseY = 0f;
        Cursor.visible = false;
    }
    private void Update()
    {
        mouseX += Input.GetAxis("Mouse X");
        mouseY -= Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(mouseY, mouseX, 0f) * sensibilidade;
    }

}
