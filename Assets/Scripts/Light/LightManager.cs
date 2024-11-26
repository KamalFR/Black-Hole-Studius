using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.ProBuilder;

public class LightManager : MonoBehaviour
{
    public bool StartAlarmLight;
    private bool _alarmTurnedOff;
    [SerializeField] private List<Light> _shipLights;
    private Color _normalShipLightColor;
    private float _normalShipLightIntensity;

    [SerializeField] private float _maxShipLightIntensity;
    [SerializeField] private float _minShipLightIntensity;
    private bool _toMaxIntensity = false;
    private float _fixedShipLightIntensity;


    // Start is called before the first frame update
    void Start()
    {
        StartAlarmLight = false;
        _alarmTurnedOff = true;
        _fixedShipLightIntensity = (_maxShipLightIntensity + _minShipLightIntensity) / 2;
        GetShipLights();
        if (_shipLights.Count > 0)
        {
            _normalShipLightColor = _shipLights[0].color;
            _normalShipLightIntensity = _shipLights[0].intensity;
        }
    }

    void FixedUpdate()
    {
        if (StartAlarmLight)
        {
            _alarmTurnedOff = false;
            StartAlarmLights();
        }
        else if (!_alarmTurnedOff)
        {
            TurnOffAlarm();
        }
    }

    void StartAlarmLights()
    {
        if (_toMaxIntensity)
        {
            // Se estiver indo para a intensidade máxima
            _fixedShipLightIntensity += Time.deltaTime;
        }
        else
        {
            // Se estiver indo para a intensidade mínima
            _fixedShipLightIntensity -= Time.deltaTime;
        }

        if ((_toMaxIntensity && _fixedShipLightIntensity >= _maxShipLightIntensity) || (!_toMaxIntensity && _fixedShipLightIntensity <= _minShipLightIntensity))
        {
            _toMaxIntensity = !_toMaxIntensity;
        }

        foreach (var shipLight in _shipLights)
        {
            if (shipLight.color != Color.red)
            {
                shipLight.color = Color.red;
            }

            shipLight.intensity = _fixedShipLightIntensity;
        }
    }

    void GetShipLights()
    {
        // Pega todas as luzes da nave
        var objectLights = GameObject.FindGameObjectsWithTag("ShipLight");

        foreach (var objectLight in objectLights)
        {
            _shipLights.Add(objectLight.GetComponent<Light>());
        }
    }

    void TurnOffAlarm()
    {
        foreach (var shipLight in _shipLights)
        {
            shipLight.color = _normalShipLightColor;
            shipLight.intensity = _normalShipLightIntensity;
        }
        _alarmTurnedOff = true;
    }
}
