using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float move = 3;
    [SerializeField] private float Run = 6;
    [SerializeField] Transform castPos;
    [SerializeField] private float baseCastDist;
    private const string LEFT = "left";
    private const string RIGHT = "right";
    private string facingDirection;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isFacingRight = true;
    void Start()
    {
        facingDirection = RIGHT;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        Animation();
        Move();

      

    }
    private void Move()
    {
        rb.velocity = new Vector2(move * (isFacingRight ? 1 : -1), rb.velocity.y);

        // Check if the enemy should turn

        if (IsHitWall() || IsNearEgde())
        {
            Flip();

        }
    }
    private void Animation()
    {
        if (rb.velocity.x > 0) { anim.SetBool("Walk",true); }
        else if (rb.velocity.x < 0) { anim.SetBool("Walk", true); }
        else  { anim.SetBool("Idle", true); }
    }
    private bool IsHitWall()
    {
        bool val = false;
        float casDist = baseCastDist;
        if(facingDirection == LEFT)
        {
            casDist = -baseCastDist;
        }
        Vector3 targetPos = castPos.position;
        targetPos.x += casDist;
        Debug.DrawLine(castPos.position, targetPos,color:Color.green);

        if(Physics2D.Linecast(castPos.position,targetPos,1 << LayerMask.NameToLayer("Ground")))
        {
            val = true;
        }
        else
        {
            val = false;
        }

        return val;
    }
    private bool IsNearEgde()
    {
        bool val = true;
        float casDist = baseCastDist;
        if (facingDirection == LEFT)
        {
            casDist = -baseCastDist;
        }
        Vector3 targetPos = castPos.position;
        targetPos.y -= casDist;
        Debug.DrawLine(castPos.position, targetPos, color: Color.red);

        if (Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Ground")))
        {
            val = false;
        }
        else
        {
            val = true;
        }

        return val;
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        rb.transform.Rotate(0, 180, 0);
    }
  
}
