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
        var end = true;

        foreach(Line line in tasks)
        {
            if (!line._isConnected) end = false;
        }

        if (end) //Se entrar aqui a task foi concluída
        {
            GameManager.instance._indexLineTask = -1;

            menu.SetActive(false);

            foreach(Line line in tasks)
            {
                line.head.position = line._startPosition;
                line._isConnected = false;
            }
        }
    }
}
