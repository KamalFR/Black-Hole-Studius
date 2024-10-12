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
        // Ray ray = Camera.main.ScreenPointToRay(Camera.main.WorldToScreenPoint(Input.mousePosition));               // Ray que sai da câmera e vai até o crosshair
        // if(Physics.Raycast(ray, out RaycastHit hit, float.MaxValue))                                 // Raycast para detectar o alvo da layer especificada em layerMask
        //     Debug.Log(hit.collider.gameObject.name);                
        // Debug.DrawRay(ray.origin, ray.direction * Vector3.Distance(ray.origin, hit.point), Color.yellow);
        mouseX += Input.GetAxis("Mouse X");
        mouseY -= Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(mouseY, mouseX, 0f) * sensibilidade;
    }

}
