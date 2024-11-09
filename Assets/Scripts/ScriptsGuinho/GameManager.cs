using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Luksguin;

public class GameManager : Singleton<GameManager>
{
    public GameObject loseMenu;

    public List<GameObject> linesTasks;
    public List<GameObject> enginesCollectables;

    [HideInInspector] public bool _taskEngineToDo;
    [HideInInspector] private bool _taskLinesToDo;
    [HideInInspector] public bool _taskOxigenToDo;

    //public int _indexLineTask;

    private void Start()
    {
        //_indexLineTask = -1;
        _taskEngineToDo = false;
        _taskLinesToDo = false;
        _taskOxigenToDo = false;
    }

    public void StartEngineTask(EngineTask task, int amount)
    {
        StartCoroutine(EngineCoroutine(task, amount));
    }

    public void StartLinesTask(int index)
    {
        _taskLinesToDo = true;
        StartCoroutine(LinesCoroutine(index));
    }
    public void StartOxigenTask()
    {
        _taskOxigenToDo = true;
        StartCoroutine(OxigenCoroutine());
    }

    IEnumerator EngineCoroutine(EngineTask task, int amount)
    {
        task.StartTask(amount);

        foreach(GameObject obj in enginesCollectables)
        {
            obj.SetActive(true);
        }

        yield return new WaitForSeconds(75f);

        if (_taskEngineToDo) loseMenu.SetActive(true);
    }

    IEnumerator LinesCoroutine(int index)
    {
        //_indexLineTask = index;
        

        yield return new WaitForSeconds(75f);

        if (_taskLinesToDo) loseMenu.SetActive(true);
    }
    IEnumerator OxigenCoroutine()
    {
        _taskLinesToDo = false;
        yield return new WaitForSeconds(75f);

        if (_taskOxigenToDo) loseMenu.SetActive(true);
    }
    public bool GetTeste()
    {
        return _taskLinesToDo;
    }
    public void SetTest(bool t)
    {
        _taskLinesToDo = t;
    }
}