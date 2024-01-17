using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleAtk : MonoBehaviour
{
    [SerializeField] private float Atk;
    [SerializeField] private string AtkObject = "Player";
    [SerializeField] private int damage;
    private HealthSystem HS;
   

    private void Start()
    {
        HS = GetComponent<HealthSystem>();
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == AtkObject )
        {
            HS.TakeDame(damage);
        }
    }
}
