using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimingGame : MonoBehaviour
{
    public Image gradientBar; // Referência à imagem da barra de gradiente
    public Image movingLine; // Referência à linha móvel
    public GameObject stopButton; // Botão para registrar a pontuação
    public Text scoreText; // Texto da pontuação
    public GameObject taskCanvas; // Canvas da task
    public float speed = 100f; // Velocidade de movimento da linha
    public int requiredScore = 80; // Pontuação necessária para completar a task

    // Pontuações configuráveis para cada área
    public int greenScore = 20;
    public int yellowScore = 10;
    public int redScore = 5;

    private RectTransform barRectTransform;
    private RectTransform lineRectTransform;
    private bool movingRight = true;
    private int currentScore = 0;

    void Start()
    {
        barRectTransform = gradientBar.GetComponent<RectTransform>();
        lineRectTransform = movingLine.GetComponent<RectTransform>();
        UpdateScore(0);
    }

    void Update()
    {
        MoveLine();
    }

    void MoveLine()
    {
        if (movingRight)
        {
            lineRectTransform.anchoredPosition += Vector2.right * speed * Time.deltaTime;
            if (lineRectTransform.anchoredPosition.x >= barRectTransform.rect.width / 2)
            {
                movingRight = false;
            }
        }
        else
        {
            lineRectTransform.anchoredPosition -= Vector2.right * speed * Time.deltaTime;
            if (lineRectTransform.anchoredPosition.x <= -barRectTransform.rect.width / 2)
            {
                movingRight = true;
            }
        }
    }

    public void CalculateScore()
    {
        float linePosition = lineRectTransform.anchoredPosition.x + barRectTransform.rect.width / 2;
        float barWidth = barRectTransform.rect.width;
        float percent = Mathf.InverseLerp(0, barWidth, linePosition);

        int score = 0;
        if (percent >= 0.45f && percent <= 0.55f)
        {
            // Parte verde
            score = greenScore;
        }
        else if (percent >= 0.35f && percent < 0.45f || percent > 0.55f && percent <= 0.65f)
        {
            // Parte amarela
            score = yellowScore;
        }
        else
        {
            // Parte vermelha
            score = redScore;
        }

        currentScore += score;
        UpdateScore(currentScore);

        if (currentScore >= requiredScore)
        {
            CompleteTask();
        }
    }

    void UpdateScore(int score)
    {
        scoreText.text = $"Score: {score}";
    }

    void CompleteTask()
    {
        Debug.Log("Task Complete!");
        taskCanvas.SetActive(false);
    }
}
