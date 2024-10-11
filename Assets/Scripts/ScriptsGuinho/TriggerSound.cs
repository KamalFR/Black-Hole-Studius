using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    public string playerTag;
    private int _index;

    public GameObject[] bichos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == playerTag)
        {
            if(_index >= bichos.Length)
            {
                _index = 0;
                for(int i = 0; i < bichos.Length; i++) bichos[i].SetActive(false);
                return;
            }

            bichos[_index].SetActive(true);
            _index++;
        }
    }
}
