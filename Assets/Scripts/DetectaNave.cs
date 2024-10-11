using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DetectaNave : MonoBehaviour
{
    public Image alertaImage; // Imagem que muda de cor
    public Color novaCor = Color.red; // Nova cor para a imagem de alerta
    private Color corOriginal;

    private void Start()
    {
        if (alertaImage) corOriginal = alertaImage.color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Nave")) alertaImage.color = novaCor;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Nave")) alertaImage.color = corOriginal;
    }
}