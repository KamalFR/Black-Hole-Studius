using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NearbyBehavior : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Se sanidade pequena para ver o monstro, aviso de não se mover
            if (other.gameObject.GetComponent<HealthHandler>().CurrentSanity < gameObject.GetComponentInParent<ShowMonsterBehavior>().SanityVisible)
            {
                GameManager.instance.isMonsterNearby = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Se se mover setar para chase
            if (other.gameObject.GetComponent<PlayerMovement>().Rb.velocity.magnitude != 0)
            {
                GetComponentInParent<MonsterBehaviour>().EnterChase = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Retirar aviso para se mover
            GameManager.instance.isMonsterNearby = false;
        }
    }


}
