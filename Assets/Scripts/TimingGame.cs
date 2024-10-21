using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimingGame : MonoBehaviour
{
    public Image gradientBar; // Referência à imagem da barra de gradiente
    public Image movingLine; // Referência à linha móvel
    public float speed = 100f; // Velocidade de movimento da linha
    public float maxLoadingTime = 5f; // Tempo máximo de carregamento
    public Text timerText; // Texto do contador de tempo
    public Button stopButton; // Botão para parar a linha móvel

    private RectTransform barRectTransform;
    private RectTransform lineRectTransform;
    private bool isMoving = true;
    private float remainingTime;
    private float stopLinePosition;

    void Start()
    {
        barRectTransform = gradientBar.GetComponent<RectTransform>();
        lineRectTransform = movingLine.GetComponent<RectTransform>();
        stopButton.onClick.AddListener(StopLine);
        remainingTime = maxLoadingTime;
    }

    void Update()
    {
        if (isMoving)
        {
            MoveLine();
        }
    }

    void MoveLine()
    {
        if (isMoving)
        {
            lineRectTransform.anchoredPosition += Vector2.right * speed * Time.deltaTime;
            if (lineRectTransform.anchoredPosition.x >= barRectTransform.rect.width / 2)
            {
                lineRectTransform.anchoredPosition = new Vector2(-barRectTransform.rect.width / 2, lineRectTransform.anchoredPosition.y);
            }
        }
    }

    void StopLine()
    {
        isMoving = false;
        stopLinePosition = lineRectTransform.anchoredPosition.x + barRectTransform.rect.width / 2;
        StartTimer();
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
        // Aqui você pode adicionar a lógica para quando o tempo se esgota
    }
}
