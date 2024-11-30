using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Luksguin;

public class EngineTask : Singleton<EngineTask>
{
    public float distance;
    public int missingEngines;

    public Transform playerCamera;
    public AudioSource alarme;

    public List<GameObject> engines;
    public List<EngineAnimation> animations;

    private bool _canCheck;

    private void Start()
    {
       _canCheck = false;
    }

    public void StartTask()
    {
        alarme.Play();
        GameManager.instance._taskEngineToDo = true;

        for (int i = 0; i < missingEngines; i++)
        {
            engines[i].SetActive(false);
        }

        foreach (EngineAnimation anim in animations)
        {
            anim._canMove = false;
        }
        _canCheck = true;

    }

    private void Update()
    {
        Debug.DrawRay(playerCamera.position, EngineAmount.instance.transform.TransformDirection(Vector3.forward) * distance, Color.red);

        if (Physics.Raycast(playerCamera.position, EngineAmount.instance.transform.TransformDirection(Vector3.forward), out RaycastHit hit, distance))
        {
            if (hit.collider.tag == "Painel" && (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.E)) && EngineAmount.instance.amount > 0)
            {
                for (int i = 0; i < engines.Count; i++)
                {
                    if (!engines[i].activeInHierarchy)
                    {
                        EngineAmount.instance.amount--;
                        engines[i].SetActive(true);
                        return;
                    }
                }
            }
        }

        int actives = 0;
        for (int i = 0; i < engines.Count; i++)
        {
            if (engines[i].activeInHierarchy) actives++;
        }

        if (actives == engines.Count) //Se entra aq significa que a task foi concluída
        {
            alarme.Pause();
            GameManager.instance._taskEngineToDo = false;
            if(_canCheck)LightManager.instance.StartAlarmLight = false;
            
            foreach (GameObject obj in GameManager.instance.enginesCollectables)
            {
                obj.SetActive(false);
            }

            foreach (EngineAnimation anim in animations)
            {
                anim._canMove = true;
            }
            _canCheck = false;

        }
    }
}
