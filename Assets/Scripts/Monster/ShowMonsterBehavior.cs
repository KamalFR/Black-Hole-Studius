using System.Collections;
using System.Collections.Generic;
using MimicSpace;
using UnityEngine;

public class ShowMonsterBehavior : MonoBehaviour
{
    [SerializeField] private Material _visibleMaterial;
    [SerializeField] private Material _invisibleMaterial;
    [SerializeField] private Material _translucentMaterial;

    [SerializeField] private GameObject _visibleLeg;
    [SerializeField] private GameObject _invisibleLeg;
    [SerializeField] private GameObject _translucentLeg;


    [SerializeField] private HealthHandler _playerHealthHandler;

    private MeshRenderer _sphereMesh;
    private Mimic _mimic;

    [SerializeField] private float _sanityTranslucent;
    [SerializeField] private float _sanityVisible;
    // Start is called before the first frame update
    void Start()
    {
        _sphereMesh = gameObject.GetComponentInChildren<MeshRenderer>();
        _mimic = gameObject.GetComponent<Mimic>();

        _sphereMesh.sharedMaterial = _invisibleMaterial;
        _mimic.legPrefab = _invisibleLeg;


    }

    // Update is called once per frame
    void Update()
    {
        CheckSanity();

    }

    void CheckSanity()
    {
        if (_playerHealthHandler.CurrentSanity > _sanityTranslucent) return;

        if (_playerHealthHandler.CurrentSanity > _sanityVisible)
        {
            if (_sphereMesh.sharedMaterial != _translucentMaterial) _sphereMesh.sharedMaterial = _translucentMaterial;
            if (_mimic.legPrefab != _translucentMaterial) _mimic.legPrefab = _translucentLeg;
            return;
        }

        if (_sphereMesh.sharedMaterial != _visibleMaterial) _sphereMesh.sharedMaterial = _visibleMaterial;
        if (_mimic.legPrefab != _visibleMaterial) _mimic.legPrefab = _visibleLeg;
    }
}
