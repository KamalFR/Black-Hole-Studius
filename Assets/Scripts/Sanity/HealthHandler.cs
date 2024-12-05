using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthHandler : MonoBehaviour
{
    private float _currentSanity;

    public float CurrentSanity
    {
        get { return _currentSanity; }
        set { _currentSanity = value; }
    }

    [SerializeField] private Slider _sanitySlider;

    [SerializeField] private float _normalSanityDecay;
    [SerializeField] private float _alertSanityDecay;
    private float _currentSanityDecay;
    private bool _endTutorial;

    // Start is called before the first frame update
    void Start()
    {
        _endTutorial = false;
        _currentSanity = 100;
        _sanitySlider.maxValue = _currentSanity;
        _sanitySlider.value = _currentSanity;
        _currentSanityDecay = _normalSanityDecay;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((GameManager.instance._taskEngineToDo || GameManager.instance._indexLineTask != -1 || GameManager.instance._taskOxigenToDo) && !_endTutorial) _endTutorial = true;
        if (_endTutorial) LowerSanity();
    }

    void LowerSanity()
    {
        _currentSanityDecay = (GameManager.instance._taskEngineToDo || GameManager.instance._indexLineTask != -1 || GameManager.instance._taskOxigenToDo) ? _alertSanityDecay : _normalSanityDecay;

        if (_currentSanity >= 0) _currentSanity -= _currentSanityDecay * Time.deltaTime;
        _sanitySlider.value = _currentSanity;
    }
}
