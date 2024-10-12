using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehave : MonoBehaviour
{
    private NaveController naveController;
    // Start is called before the first frame update
    void Start()
    {
        naveController = GameObject.FindWithTag("Nave").GetComponent<NaveController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
