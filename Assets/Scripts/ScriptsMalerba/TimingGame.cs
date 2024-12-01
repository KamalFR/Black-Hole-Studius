using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimingGame : MonoBehaviour
{
    public Image gradientBar; // Referência à imagem da barra de gradiente
    public Image movingLine; // Referência à linha móvel
    public GameObject stopButton; // Botão para registrar a pontuação
    public Slider ScoreSlider;
    public GameObject taskCanvas; // Canvas da task
    public float speed = 100f; // Velocidade de movimento da linha
    public int requiredScore = 80; // Pontuação necessária para completar a task

    // Pontuações configuráveis para cada área
    public int greenScore;
    public int yellowScore;
    public int redScore;

    private RectTransform barRectTransform;
    private RectTransform lineRectTransform;
    private bool movingRight = true;
    private int currentScore = 0;

    void Start()
    {
        ScoreSlider.maxValue = requiredScore;
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
            lineRectTransform.anchoredPosition += Vector2.up * speed * Time.deltaTime;
            if (lineRectTransform.anchoredPosition.y >= barRectTransform.rect.width / 2)
            {
                movingRight = false;
            }
        }
        else
        {
            lineRectTransform.anchoredPosition -= Vector2.up * speed * Time.deltaTime;
            if (lineRectTransform.anchoredPosition.y <= -barRectTransform.rect.width / 2)
            {
                movingRight = true;
            }
        }
    }

    public void CalculateScore()
    {
        float linePosition = lineRectTransform.anchoredPosition.y + barRectTransform.rect.width / 2;
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
        Debug.Log(score);
        ScoreSlider.value = score;
    }

    void CompleteTask()
    {
        GameManager.instance._taskOxigenToDo = false;
        taskCanvas.SetActive(false);
        LightManager.instance.StartAlarmLight = false;
        currentScore = 0;
    }
}
