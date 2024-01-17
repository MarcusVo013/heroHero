using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    AudioManger audioManger;
    private Animator anim;
    [SerializeField]private float maxhealth;
    [SerializeField] private float Def;
    [SerializeField] EnemyHealthBar healthBar;
    private Dead dead;
    private float health;
    private void Awake()
    {
        audioManger = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManger>();
        healthBar = GetComponentInChildren<EnemyHealthBar>();
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        dead = GetComponent<Dead>();
        health = maxhealth;
        healthBar.UpdateHealthBar(health, maxhealth);
    }



    void Update()
    {

    }
  
    public void TakeDame(float Damage)
    {

        health -= Damage;
        audioManger.PlaySFX(audioManger.hitenemy);
        healthBar.UpdateHealthBar(health, maxhealth);
        Debug.Log("Damage Taken");
        anim.SetTrigger("Hurt");
        EnemyDie();
    }
    public void EnemyDie()
    {
        if (health <= 0)
        {
            audioManger.PlaySFX(audioManger.enemyDead);
            Destroy(gameObject);
        }

    }

    
}
