using EZCameraShake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float health = 200;
    private Animator anim;
    public float currentHealth;
    private float HealAmount = 50;
    private BossDead dead;
    public float potion;
    AudioManger audioManger;
    private void Awake()
    {
        audioManger = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManger>();
    }
    void Start()
    {
        dead = GetComponent<BossDead>();
        anim = GetComponent<Animator>();
        currentHealth = health;

        healthBar.SetSliderValue(currentHealth / health);
        
    }

    private void OnDestroy()
    {
        
    }

    private void EmptyHealth()
    {
        currentHealth = 0;
        healthBar.SetSliderValue(0);
    }
    public void TakeDame(int damage)
    {

        audioManger.PlaySFX(audioManger.BossHit);
        currentHealth -= damage;
        healthBar.SetSliderValue(currentHealth / health);
        anim.SetTrigger("Hurt");
        PLayerNoHealth();       
    }
    private void PLayerNoHealth()
    {
        if (currentHealth <= 0)
        {
            anim.SetBool("Dead", true);
            Debug.Log("PlayerDeath");
            dead.Die();
        }
    }
}
