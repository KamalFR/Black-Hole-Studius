using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SliderAudio : MonoBehaviour
{
    public AudioMixer audioMixer;
    public string floatParam;

    public void ChangeValue(float f)
    {
        audioMixer.SetFloat(floatParam, f);
    }
}
