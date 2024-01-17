using System;
using UnityEngine;

public class Dead : MonoBehaviour
{
    private BoxCollider2D box;
    private Rigidbody2D rb;
    private Animator anim;
    private bool died;
    public event System.Action OnDead;
    public static Action OnPlayerDeath;
    AudioManger audioManger;
    [SerializeField] GameObject gameObject;
    [SerializeField] private int TrapDamge = 40 ;
    [SerializeField] Shoot shoot;

    private void Awake()
    {
        audioManger = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManger>();
    }
    private void Start()
    {
        
        box = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        died = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthSystem healthSystem = collision.GetComponent<HealthSystem>();
        if (healthSystem != null)
        {
            healthSystem.TakeDame(TrapDamge);
        }
    }

    public void Die()
    {      
        audioManger.PlaySFX(audioManger.death);
        shoot.enabled = false;
        rb.velocity = Vector3.zero;
        anim.SetBool("Dead", true);
        died = true;
        OnPlayerDeath?.Invoke();
        OnDead?.Invoke();
        if (died) { return; }
    }
}
