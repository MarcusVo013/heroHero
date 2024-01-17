using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    public float attackRange = 5f;
    public float timeBetweenAttacks = 2f;
    public Transform attackPoint;
    public GameObject projectilePrefab;
    public Transform target;
    private Animator anim;

    private Transform player;
    private bool isAttacking = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        Flip();
       
    }
    public void StartAttack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            InvokeRepeating("Attack", 0f, timeBetweenAttacks);
        }
    }

    public void StopAttack()
    {
        if (isAttacking)
        {
            isAttacking = false;
            CancelInvoke("Attack");
        }
    }


    private void Attack()
    {
        anim.SetTrigger("RangeAtk");
        // Instantiate and launch a projectile towards the player
        GameObject projectile = Instantiate(projectilePrefab, attackPoint.position, transform.rotation);
        Vector2 direction = (player.position - attackPoint.position).normalized;
        projectile.GetComponent<Rigidbody2D>().velocity = direction * 10f;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x)
        {
            rotation.y = -180f;
        }
        else
        {
            rotation.y = 0f;
        }
        transform.eulerAngles = rotation;
    }
}
