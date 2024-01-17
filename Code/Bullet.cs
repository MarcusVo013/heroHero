using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int Damage;
    [SerializeField] private Rigidbody2D Shooter;
    [SerializeField] private GameObject ImpactEffect;

    AudioManger audioManger;
    private Rigidbody2D rb;
    private bool HitEnemy = true;
    private void Awake()
    {
        audioManger = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManger>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Shooter = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        audioManger.PlaySFX(audioManger.fireball);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                audioManger.PlaySFX(audioManger.explotion);
                enemy.TakeDame(Damage);
                Instantiate(ImpactEffect, transform.position, Quaternion.identity);
                
                Destroy(gameObject);
            }
            BossHealth boss = collision.GetComponent<BossHealth>();
            if (boss != null) 
            {
                audioManger.PlaySFX(audioManger.explotion);
                boss.TakeDame(Damage);
                Instantiate(ImpactEffect, transform.position, Quaternion.identity);

                Destroy(gameObject);
            }
            Destroy(gameObject);

        }

    }
}
