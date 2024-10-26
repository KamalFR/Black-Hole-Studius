using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Luksguin;

public class GameManager : Singleton<GameManager>
{
    public GameObject loseMenu;

    [HideInInspector] public bool _taskEngineToDo;
    [HideInInspector] public bool _taskLinesToDo;

    [HideInInspector] public bool _startLineTask;

    public void StartEngineTask(EngineTask task, int amount)
    {
        StartCoroutine(EngineCoroutine(task, amount));
    }

    IEnumerator EngineCoroutine(EngineTask task, int amount)
    {
        task.StartTask(amount);

        yield return new WaitForSeconds(25f);

        if(_taskEngineToDo) loseMenu.SetActive(true);
    }

    IEnumerator LinesCoroutine()
    {
        _startLineTask = true;

        yield return new WaitForSeconds(25f);

        if (_taskLinesToDo) loseMenu.SetActive(true);
    }
}
