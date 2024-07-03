using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseController : MonoBehaviour
{
    Transform _target;

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    //chase target (No retreat) - 50 puntos
    // look at target: 10 puntos
    // move to target: 40 puntos
}
