using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityHealInteract : MonoBehaviour
{
    [SerializeField] private float range = 10f;
    [SerializeField] private HealthHandler _playerHealthRenderer;
    [SerializeField] private float _healSanityValue;

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit, range))
        {
            if (hit.collider.tag == "SanityPill")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _playerHealthRenderer.CurrentSanity += _healSanityValue;
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
