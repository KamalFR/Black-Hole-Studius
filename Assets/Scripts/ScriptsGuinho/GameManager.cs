using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Luksguin;

public class GameManager : Singleton<GameManager>
{
    public GameObject loseMenu;

    public List<GameObject> linesTasks;

    [HideInInspector] public bool _taskEngineToDo;
    [HideInInspector] public bool _taskLinesToDo;

    public int _indexLineTask;

    private void Start()
    {
        _indexLineTask = -1;
    }

    public void StartEngineTask(EngineTask task, int amount)
    {
        StartCoroutine(EngineCoroutine(task, amount));
    }

    public void StartLinesTask(int index)
    {
        StartCoroutine(LinesCoroutine(index));
    }

    IEnumerator EngineCoroutine(EngineTask task, int amount)
    {
        task.StartTask(amount);

        yield return new WaitForSeconds(25f);

        if (_taskEngineToDo) loseMenu.SetActive(true);
    }

    IEnumerator LinesCoroutine(int index)
    {
        _indexLineTask = index;
        _taskLinesToDo = true;

        yield return new WaitForSeconds(25f);
        Debug.Log("Cabou fi");

        if (_taskLinesToDo) loseMenu.SetActive(true);
    }
}