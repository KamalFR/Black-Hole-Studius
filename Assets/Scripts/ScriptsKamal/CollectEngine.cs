using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectEngine : MonoBehaviour
{
    [SerializeField] private float range = 10f;
    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit, range))
        {
            if(hit.collider.tag == "Engine") 
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    EngineAmount.instance.amount++;
                    hit.collider.gameObject.SetActive(false);
                }
            }
        }
    }
}
