using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAtk : MonoBehaviour
{
    private EnemyRange enemyRange;

    private void Start()
    {
        enemyRange = GetComponent<EnemyRange>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyRange.StartAttack();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyRange.StopAttack();
        }
    }
}
