using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Luksguin;

public class GameManager : Singleton<GameManager>
{
    public EngineTask engineTask;
    public int missingEngines;

    public GameObject winMenu;
    public GameObject loseMenu;

    [HideInInspector] public bool _taskEngineToDo;
    [HideInInspector] public bool _taskLinesToDo;

    [HideInInspector] public bool _startLineTask;

    private void Start()
    {
        StartCoroutine(TheGameCoroutine());
    }

    IEnumerator TheGameCoroutine()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Começou");

        engineTask.StartTask(missingEngines);

        yield return new WaitForSeconds(25f);

        if (_taskEngineToDo)
        {
            loseMenu.SetActive(true);
            yield break;
        }
        Debug.Log("Primeira foi");

        _startLineTask = true;
        _taskLinesToDo = true;

        yield return new WaitForSeconds(15f);

        if (_taskLinesToDo)
        {
            loseMenu.SetActive(true);
            yield break;
        }
        Debug.Log("Deu Bom");

        winMenu.SetActive(true);
    }
}
