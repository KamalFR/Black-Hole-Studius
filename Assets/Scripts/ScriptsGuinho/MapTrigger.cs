using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTrigger : MonoBehaviour
{
    public GameObject winMenu;
    public bool isTask;

    [Header("IGNORAR CASO NÃO SEJA TASK!!!")]
    public bool engine;
    public bool line;

    public int missingEngines;

    public EngineTask engineTask;

    private void Start()
    {
        line = !engine;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Nave")) return;

        if(!isTask)
        {
            winMenu.SetActive(true);
        }
        else
        {
            if (engine) GameManager.instance.StartEngineTask(engineTask, missingEngines);
            if (line) GameManager.instance.StartLinesTask();
        }

        Destroy(gameObject);
    }
}
