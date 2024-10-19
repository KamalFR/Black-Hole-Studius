using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineTask : MonoBehaviour
{
    public float distance;

    public List<GameObject> engines;
    public List<EngineAnimation> animations;

    private void Update()
    {
        Debug.DrawRay(EngineAmount.instance.transform.position, EngineAmount.instance.transform.TransformDirection(Vector3.forward) * distance, Color.red);

        if (Physics.Raycast(EngineAmount.instance.transform.position, EngineAmount.instance.transform.TransformDirection(Vector3.forward), out RaycastHit hit, distance))
        {
            if (hit.collider.tag == "Painel" && Input.GetKeyDown(KeyCode.Mouse0) && EngineAmount.instance.amount > 0)
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

        if (actives == engines.Count)
        {
            //Se entra aq significa que a task foi concluída
            foreach (EngineAnimation anim in animations)
            {
                anim._canMove = true;
            }
        }
    }
}
