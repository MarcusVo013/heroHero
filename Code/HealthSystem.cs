using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using EZCameraShake;

public class HealthSystem : MonoBehaviour
{
    //[SerializeField] private GameObject character;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float health =200;
    private Animator anim;
    public float currentHealth;
    private float HealAmount = 50;
    private Dead dead;
    public float potion;
    AudioManger audioManger;
    private void Awake()
    {
        audioManger = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManger>();
    }
    void Start()
    {
        dead = GetComponent<Dead>();
        anim = GetComponent<Animator>();
        currentHealth = health;

        healthBar.SetSliderValue(currentHealth / health);
        dead.OnDead += EmptyHealth;
    }

    //private void OnDestroy()
    //{
    //    dead.OnDead -= EmptyHealth;
    //}

    private void EmptyHealth()
    {
        currentHealth = 0;
        healthBar.SetSliderValue(0);
    }

    void cheat()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete)) 
        {
            health = 100000;
            currentHealth = 100000;
        }

        PressToHeal();
    }
    private void UseHealthPotion()
    {
        ItemCollection _items = GetComponent<ItemCollection>();
        if (_items.HP > 0)
        {
            
            _items.HP--;
            _items.HealthPotions.text = ("X " + _items.HP);
            potion = _items.HP;
            audioManger.PlaySFX(audioManger.healUse);
            HealPlayer(HealAmount);
            if(currentHealth > health)
            { currentHealth = health; }
            healthBar.SetSliderValue(currentHealth / health);
        }
        else
        {
            Debug.Log("No health potions left.");
        }
    }

    public void TakeDame(int damage)
    {
        
        audioManger.PlaySFX(audioManger.playerHit);
        currentHealth -= damage;
        healthBar.SetSliderValue(currentHealth / health);
        anim.SetTrigger("Hurt");
        PLayerNoHealth();
        CameraShaker.Instance.ShakeOnce(4f, 4f, .2f, 1f);
        
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
    private void PressToHeal()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            UseHealthPotion();
        }
    }
    private void HealPlayer(float amount)
    {
        currentHealth += amount;
    }

}
