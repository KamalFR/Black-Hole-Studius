using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskCompleted : MonoBehaviour
{
    public GameObject menu;
    public List<Line> tasks;

    [HideInInspector] public bool _isCompleted = false;

    private void Update()
    {
        if (tasks.Count == 0) //Se entrar aqui a task foi concluída
        {
            GameManager.instance._taskLinesToDo = false;
            GameManager.instance._indexLineTask = -1;

            menu.SetActive(false);
        }

        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i]._isConnected == true) tasks.Remove(tasks[i]);
        }
    }
}