using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;

    private void Start()
    {
        transform.position = _startPoint.position;
    }
}
