using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimingTask : MonoBehaviour
{
    public Image gradientBar; // Referência à imagem da barra de gradiente
    public Image movingLine; // Referência à linha móvel
    public float speed = 100f; // Velocidade de movimento da linha
    public float maxLoadingTime = 5f; // Tempo máximo de carregamento
    public Text timerText; // Texto do contador de tempo
    public GameObject stop;


    private RectTransform barRectTransform;
    private RectTransform lineRectTransform;
    private bool isMoving = true;
    private float remainingTime;
    private float stopLinePosition;

    void Start()
    {
        barRectTransform = gradientBar.GetComponent<RectTransform>();
        lineRectTransform = movingLine.GetComponent<RectTransform>();
        remainingTime = maxLoadingTime;
    }

    void Update()
    {
        if (isMoving)
        {
            MoveLine();
        }

        if (remainingTime <= 0)  
        {
            gameObject.SetActive(false);
        }
    }

    public void MoveLine()
    {
        lineRectTransform.anchoredPosition += Vector2.right * speed * Time.deltaTime;
        if (lineRectTransform.anchoredPosition.x >= barRectTransform.rect.width / 2)
        {
            lineRectTransform.anchoredPosition = new Vector2(-barRectTransform.rect.width / 2, lineRectTransform.anchoredPosition.y);
        }
    }

    public void StopLine() // Torne este método público
    {
        Debug.Log("StopLine foi chamado");
        isMoving = false;
        stopLinePosition = lineRectTransform.anchoredPosition.x + barRectTransform.rect.width / 2;
        StartTimer();
        stop.SetActive(false);
    }

    void StartTimer()
    {
        float barWidth = barRectTransform.rect.width;
        float percent = Mathf.InverseLerp(0, barWidth, stopLinePosition);
        float subtractTime = Mathf.Lerp(0, maxLoadingTime, percent);

        remainingTime = maxLoadingTime - subtractTime;
        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        while (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            timerText.text = $"Tempo: {remainingTime:F2}";
            yield return null;
        }
        Debug.Log("Tempo esgotado!");
        
    }
}

