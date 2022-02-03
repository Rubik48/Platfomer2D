using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiePlayer : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            transform.position = _startPoint.position;
        }
    }
}
