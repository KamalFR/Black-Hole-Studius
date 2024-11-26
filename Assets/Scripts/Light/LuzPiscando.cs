using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    private Light lightSource; // Referência à luz
    public float flickerIntervalMin = 0.1f; // Intervalo mínimo entre piscadas
    public float flickerIntervalMax = 0.5f; // Intervalo máximo entre piscadas
    private float nextFlickerTime; // Tempo para a próxima troca de estado

    void Start()
    {
        // Obtém o componente Light no objeto atual
        lightSource = GetComponent<Light>();
        SetNextFlickerTime(); // Define o tempo inicial para o primeiro piscar
    }

    void Update()
    {
        // Checa se o tempo chegou para o próximo piscar
        if (Time.time >= nextFlickerTime)
        {
            FlickerLight(); // Troca o estado da luz
            SetNextFlickerTime(); // Define o tempo para o próximo piscar
        }
    }

    void FlickerLight()
    {
        // Alterna entre acender (1) e apagar (0) a luz
        lightSource.intensity = (lightSource.intensity == 0f) ? 1f : 0f;
    }

    void SetNextFlickerTime()
    {
        // Define o próximo intervalo aleatório para a troca de estado da luz
        nextFlickerTime = Time.time + Random.Range(flickerIntervalMin, flickerIntervalMax);
    }
}
