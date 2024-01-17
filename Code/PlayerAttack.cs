using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    #region Public;
    
    #endregion

    #region Private;
    private Animator anim;
    [SerializeField]private GameObject attackArea;
    private bool attacking = false;
    private float timetoatk = 0.25f;
    private float time = 1f;
    #endregion

    private void Start()
    {
        anim = GetComponent<Animator>();
       
        
    }

    

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && !attacking ) 
        {
            Attack();
        }
        if(attacking)
        {
            time += Time.deltaTime;
            attacking = false;
            attackArea.SetActive(attacking);
        }
        
    }
    
     void Attack()
    {
       attacking = true;
        anim.SetTrigger("Attack");
        attackArea.SetActive(attacking);
        
    }
   
}
