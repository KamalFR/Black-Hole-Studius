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

    private bool _isMonsterNearby;
    public bool isMonsterNearby { get { return _isMonsterNearby; } set { _isMonsterNearby = value; } }
    public string MonsterNearbyAlarm;
    public string CurrentTextDisplay;

    public List<GameObject> linesTasks;
    public List<GameObject> enginesCollectables;

    [HideInInspector] public bool _taskEngineToDo;
    [HideInInspector] public bool _taskOxigenToDo;
    public int _indexLineTask;

    private void Start()
    {
        _indexLineTask = -1;
        _taskEngineToDo = false;
        _taskOxigenToDo = false;
        _isMonsterNearby = false;
    }

    public void StartEngineTask()
    {
        StartCoroutine(EngineCoroutine());
        StartCoroutine(AmbianceCoroutine());
    }

    public void StartLinesTask(int index)
    {
        StartCoroutine(LinesCoroutine(index));
        StartCoroutine(AmbianceCoroutine());
    }

    public void StartOxigenTask()
    {
        StartCoroutine(OxigenCoroutine());
        StartCoroutine(AmbianceCoroutine());
    }

    public void Update()
    {
        if (_isMonsterNearby)
        {
            gameObjectAlarm.SetActive(true);
            tmpAlarm.text = MonsterNearbyAlarm;
        }
        else
        {
            tmpAlarm.text = CurrentTextDisplay;
            if (!(_indexLineTask != -1 || _taskEngineToDo || _taskOxigenToDo)) gameObjectAlarm.SetActive(false);
        }
    }

    IEnumerator EngineCoroutine()
    {
        tmpAlarm.text = textEngineAlarm;
        CurrentTextDisplay = tmpAlarm.text;

        EngineTask.instance.StartTask();

        for (int i = 0; i < EngineTask.instance.missingEngines; i++)
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
        CurrentTextDisplay = tmpAlarm.text;

        yield return new WaitForSeconds(75f);

        if (_indexLineTask != -1) loseMenu.SetActive(true);
    }
    IEnumerator OxigenCoroutine()
    {
        _taskOxigenToDo = true;
        tmpAlarm.text = textGasAlarm;
        CurrentTextDisplay = tmpAlarm.text;

        yield return new WaitForSeconds(75f);

        if (_taskOxigenToDo) loseMenu.SetActive(true);
    }

    IEnumerator AmbianceCoroutine()
    {
        LightManager.instance.StartAlarmLight = true;

        while (_indexLineTask != -1 || _taskEngineToDo || _taskOxigenToDo)
        {
            if (!_isMonsterNearby)
            {
                gameObjectAlarm.SetActive(true);
                yield return new WaitForSeconds(1f);
                gameObjectAlarm.SetActive(false);
                yield return new WaitForSeconds(1f);
            }
            else
            {
                yield return null;
            }

        }
    }
}
