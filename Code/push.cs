using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push : MonoBehaviour
{
    [SerializeField] private int Damage = 10;
    public float knockbackForce = 10f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            BossHealth boss=collision.GetComponent<BossHealth>();
            if (enemy != null)
            { 
                enemy.TakeDame(Damage);
               
               
            }
            if(boss != null)
            {
                boss.TakeDame(Damage);
            }

            if (collision.CompareTag("Enemy") || boss != null)
            {
                // Apply knockback force to the enemy object
                Rigidbody2D enemyRigidbody = collision.GetComponent<Rigidbody2D>();
                if (enemyRigidbody != null)
                {
                    Vector2 knockbackDirection = collision.transform.position - transform.position;
                    knockbackDirection.Normalize();
                    enemyRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
                }
            }

        }

    }
}
