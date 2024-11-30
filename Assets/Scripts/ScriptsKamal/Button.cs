using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private EnumBotoes tipo;
    public EnumBotoes GetTipo() 
    { 
        return tipo; 
    }
}
