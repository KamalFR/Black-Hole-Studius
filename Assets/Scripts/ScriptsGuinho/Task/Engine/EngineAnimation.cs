using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineAnimation : MonoBehaviour
{
    public float speed;
    public Animator myAnimator;

    [HideInInspector] public bool _canMove = false;

    private void Update()
    {
        if (_canMove)
        {
            myAnimator.speed = speed;
        }
        else
        {
            myAnimator.speed = 0;
        }
    }
}
