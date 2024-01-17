using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;

    private Animator anim;
    private float currentHealth;
    private Dead dead;

    void Start()
    {
        dead = GetComponent<Dead>();
        anim = GetComponent<Animator>();
        currentHealth = health;
        dead.OnDead += EmptyHealth;
        
    }

    private void OnDestroy()
    {
        dead.OnDead -= EmptyHealth;
    }
    private void EmptyHealth()
    {
        currentHealth = 0;
       
    }
    public void TakeDame(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            dead.Die();
            Destroy(gameObject);
        }
        

    }
}
