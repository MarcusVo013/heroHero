using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movement : MonoBehaviour
{
    public GameObject Object;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;
    private bool BlockMove;
    private Dead dead;
    private float dirx = 0.0f;

    private readonly Quaternion leftDirection = Quaternion.Euler(0, 180, 0);
    private readonly Quaternion rightDirection = Quaternion.Euler(0, 0, 0);

    [SerializeField] private LayerMask JumpGround;
    [SerializeField] private float walkspeed = 3;
    [SerializeField] private float runspeed = 7;

    private enum MovementState { Idle, Walk, Run, Fall };
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        BlockMove = false;
    }

    void Update()
    {
        if (BlockMove) return;
        Move();
        Animation_Update();
    }
    private void Move()
    {
        rb.velocity = new Vector2(dirx * runspeed, rb.velocity.y);
        {
            if (rb.velocity.x > 0)
            { Object.transform.rotation = rightDirection; }
            else if (rb.velocity.x < 0)
            { Object.transform.rotation = leftDirection; }
        }
    }
    private void OnEnable()
    {
        dead.OnDead += BlockMovement;
    }

    private void OnDisable()
    {
        dead.OnDead -= BlockMovement;
    }
    private void BlockMovement()
    {
        BlockMove = true;
    }
    private void Animation_Update()
    {
        MovementState state;
        if (dirx > 0)
        {
            state = MovementState.Walk;
            
        }
        else if (dirx < 0)
        {
            state = MovementState.Walk;
            

        }
        else
        {
            state = MovementState.Idle;
        }
        //if (rb.velocity.y > .1f)
        //{
        //    state = MovementState.Jump;
        //}
        //else if (rb.velocity.y < -.1f)
        //{
        //    state = MovementState.Fall;
        //}
        anim.SetInteger("State", (int)state);
    }
}
