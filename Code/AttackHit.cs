using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHit : MonoBehaviour
{

    public event Action<Dead> OnHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Dead>(out Dead dead))
        {
            OnHit?.Invoke(dead);
        }
    }
}
