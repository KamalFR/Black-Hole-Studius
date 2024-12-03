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
    }

    [SerializeField] private Slider _sanitySlider;

    [SerializeField] private float _normalSanityDecay;
    [SerializeField] private float _alertSanityDecay;
    private float _currentSanityDecay;

    // Start is called before the first frame update
    void Start()
    {
        _currentSanity = 100;
        _sanitySlider.maxValue = _currentSanity;
        _sanitySlider.value = _currentSanity;
        _currentSanityDecay = _normalSanityDecay;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LowerSanity();
    }

    void LowerSanity()
    {
        _currentSanityDecay = GameManager.instance._indexLineTask == -1 ? _normalSanityDecay : _alertSanityDecay;

        Debug.Log(GameManager.instance._indexLineTask);

        _currentSanity -= _currentSanityDecay * Time.deltaTime;
        _sanitySlider.value = _currentSanity;
    }
}
