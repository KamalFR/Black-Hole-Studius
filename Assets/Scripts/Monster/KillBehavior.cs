using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class KillBehavior : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _virtualCamera;
    [SerializeField] GameObject Canva;

    [SerializeField] private AudioClip deathClip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Se sanidade pequena para ver o monstro, aviso de não se mover
            if (other.gameObject.GetComponent<HealthHandler>().CurrentSanity < gameObject.GetComponentInParent<ShowMonsterBehavior>().SanityVisible)
            {
                StartCoroutine(KillPlayer());
            }
        }
    }

    IEnumerator KillPlayer()
    {
        AudioSource audioSource = transform.parent.gameObject.GetComponentInChildren<AudioSource>();
        audioSource.loop = false;
        audioSource.clip = deathClip;
        audioSource.Play();

        _virtualCamera.enabled = true;
        Canva.SetActive(false);
        yield return new WaitForSeconds(2f);
        Canva.SetActive(true);
        GameManager.instance.loseMenu.SetActive(true);
    }
}
