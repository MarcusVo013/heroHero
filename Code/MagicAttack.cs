using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAttack : MonoBehaviour
{
    [SerializeField] private Transform AtkPos;
    [SerializeField] private LayerMask Enemy;
    [SerializeField] private Animator PlayerAnim;
    [SerializeField] private Animator CamAnim;
    [SerializeField] private float AtkRangeX;
    [SerializeField] private float AtkRangeY;
    [SerializeField] private int Damage;
    [SerializeField] private float attackSpeed = 1.0f;
    private float lastAttackTime = 0.0f;
    private void Start()
    {
       
    }
    void Update()
    {
            Attack();      
    }
   
    public bool CanAttack()
    {
        float currentTime = Time.time;
        float elapsedTime = currentTime - lastAttackTime;
        return elapsedTime >= attackSpeed;
    }
    private void Attack()
    {
        if (Input.GetButtonDown("Fire1") && CanAttack())
        {
            PlayerAnim.SetTrigger("Attack");
            Collider2D[] EnemiesToHit = Physics2D.OverlapBoxAll(AtkPos.position,new Vector2 (AtkRangeX,AtkRangeY),0,Enemy);
            for(int i =0; i < EnemiesToHit.Length; i++)
            {
                EnemiesToHit[i].GetComponent<Enemy>().TakeDame(Damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(AtkPos.position, new Vector3(AtkRangeX, AtkRangeY,1));
    }
    
}
