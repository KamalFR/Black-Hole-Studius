using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Luksguin;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public GameObject loseMenu;

    public GameObject gameObjectAlarm;
    public TextMeshProUGUI tmpAlarm;
    public string textLinesAlarm;
    public string textEngineAlarm;
    public string textGasAlarm;

    public List<GameObject> linesTasks;
    public List<GameObject> enginesCollectables;

    [HideInInspector] public bool _taskEngineToDo;
    [HideInInspector] public bool _taskOxigenToDo;
    [HideInInspector] public int _indexLineTask;

    private void Start()
    {
        _indexLineTask = -1;
        _taskEngineToDo = false;
        _taskOxigenToDo = false;
    }

    public void StartEngineTask()
    {
        StartCoroutine(EngineCoroutine());
        StartCoroutine(TextCoroutine());
    }

    public void StartLinesTask(int index)
    {
        StartCoroutine(LinesCoroutine(index));
        StartCoroutine(TextCoroutine());
    }

    public void StartOxigenTask()
    {
        StartCoroutine(OxigenCoroutine());
        StartCoroutine(TextCoroutine());
    }

    IEnumerator EngineCoroutine()
    {
        tmpAlarm.text = textEngineAlarm;

        EngineTask.instance.StartTask();

        for(int i = 0; i < EngineTask.instance.missingEngines; i++)
        {
            var index = Random.Range(0, enginesCollectables.Count);
            
            if (enginesCollectables[index].activeInHierarchy) i--;
            else enginesCollectables[index].SetActive(true);
        }

        yield return new WaitForSeconds(75f);

        if (_taskEngineToDo) loseMenu.SetActive(true);
    }

    IEnumerator LinesCoroutine(int index)
    {
        _indexLineTask = index;
        tmpAlarm.text = textLinesAlarm + _indexLineTask;

        yield return new WaitForSeconds(75f);

        if (_indexLineTask != -1) loseMenu.SetActive(true);
    }
    IEnumerator OxigenCoroutine()
    {
        _taskOxigenToDo = true;
        tmpAlarm.text = textGasAlarm;

        yield return new WaitForSeconds(75f);

        if (_taskOxigenToDo) loseMenu.SetActive(true);
    }

    IEnumerator TextCoroutine()
    {
        while (_indexLineTask != -1 || _taskEngineToDo || _taskOxigenToDo)
        {
            gameObjectAlarm.SetActive(true);
            yield return new WaitForSeconds(1f);
            gameObjectAlarm.SetActive(false);
            yield return new WaitForSeconds(1f);
        }
    }

    /*public bool GetTeste()
    {
        return _taskLinesToDo;
    }
    public void SetTest(bool t)
    {
        _taskLinesToDo = t;
    }*/
}
