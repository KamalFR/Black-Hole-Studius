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
        if (alertaImage != null)
        {
            corOriginal = alertaImage.color;
            Debug.Log("Cor original armazenada: " + corOriginal);
        }
        else
        {
            Debug.LogError("AlertaImage não está atribuído!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D chamado com " + other.name);

        if (other.CompareTag("Nave"))
        {
            Debug.Log("Nave detectada. Mudando cor para: " + novaCor);
            alertaImage.color = novaCor;
            Debug.Log("Cor atual da alertaImage: " + alertaImage.color);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("OnTriggerExit2D chamado com " + other.name);

        if (other.CompareTag("Nave"))
        {
            Debug.Log("Nave saiu. Restaurando cor para: " + corOriginal);
            alertaImage.color = corOriginal;
            Debug.Log("Cor restaurada da alertaImage: " + alertaImage.color);
        }
    }
}