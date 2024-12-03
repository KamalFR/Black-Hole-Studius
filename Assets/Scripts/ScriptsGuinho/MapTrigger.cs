using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTrigger : MonoBehaviour
{
    public GameObject winMenu;

    public bool isTask;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Nave")) return;

        if (!isTask)
        {
            winMenu.SetActive(true);
        }
        else
        {
            var index = Random.Range(0, 0);
            Debug.Log(index);
            if (index == 0) GameManager.instance.StartEngineTask();
            else if (index == 1) GameManager.instance.StartLinesTask(Random.Range(0, GameManager.instance.linesTasks.Count));
            else GameManager.instance.StartOxigenTask();
        }

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var index = Random.Range(0, 3);
        Debug.Log(index);
        if (index == 0) GameManager.instance.StartEngineTask();
        else if (index == 1) GameManager.instance.StartLinesTask(Random.Range(0, GameManager.instance.linesTasks.Count));
        else GameManager.instance.StartOxigenTask();
    }
}
