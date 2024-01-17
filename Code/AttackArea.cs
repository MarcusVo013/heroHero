using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private float damage = 0f;
    [SerializeField]public Charsta charsta;

    private void Start()
    {
        charsta = GetComponent<Charsta>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Enemy>()!= null)
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.TakeDame(damage);
        }
    }
}
