using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineCollectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            EngineAmount.instance.amount++;
            Destroy(gameObject);
        }
    }
}
