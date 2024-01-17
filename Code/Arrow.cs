using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int Damage;
    [SerializeField] private Rigidbody2D Shooter;
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
        audioManger.PlaySFX(audioManger.arrowfire);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            HealthSystem HS = collision.GetComponent<HealthSystem>();
            if (collision.CompareTag("Player"))
            {
                HS.TakeDame(Damage);
                audioManger.PlaySFX(audioManger.arrowhit);
                Destroy(gameObject);
            }
            

            Destroy(gameObject);

        }

    }
}
