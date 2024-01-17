using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    #region
    //public GameObject Object;
    //public float PositionX;
    //public float PositionY;
    #endregion
    #region
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private float dirx = 0.0f;
    public Dead dead;
    private bool BlockMove;
    private bool StopJump;
    private bool facingright = true;
    private bool IsRun = false;
    private TrailRenderer trailRenderer;
    private enum MovementState { Idle, Walk, Jump, Fall, Run };
    private MovementState state = MovementState.Idle;
    [SerializeField] private LayerMask JumpGround;
    [SerializeField] private float jumpforce = 7;
    [SerializeField] private float Runspeed = 5;
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float lowJumpMultiplier = 2f;
    #endregion
    #region[Dashing]
    [SerializeField] private float dashVelocity = 14f;
    [SerializeField] private float dashTime = 0.5f;
    private Vector2 dashDir;
    private bool isDash;
    private bool canDash =true;
    #endregion
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        trailRenderer = GetComponent<TrailRenderer>();
        BlockMove = false;
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
    void Update()
    {
        if (BlockMove) return;
        PlayerMove();
        Animation_Update();
        fall();
        //Dash();
    }
    //public void PlayerPosition()
    //{
    //    PositionX = Object.transform.position.x;
    //    PositionY = Object.transform.position.y;
    //}
    private void PlayerMove()
    {
        dirx = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(dirx * Runspeed, rb.velocity.y);
            {
                if (rb.velocity.x > 0 && !facingright)
                {
                    Flip();
                }
                else if (rb.velocity.x < 0 && facingright)
                {
                    Flip();
                }
            }      
        Jump();
    }
    private void Dash()
    {
        if (Input.GetButtonDown("Dash") && canDash)
        {
            isDash = true;
            canDash = false;
            trailRenderer.emitting = true;
            dashDir = new Vector2(x:Input.GetAxisRaw("Horizontal"),y:Input.GetAxisRaw("Vertical"));
            if (dashDir ==Vector2.zero)
            {
                dashDir = new Vector2(transform.localScale.x,y:0);
            }
            StartCoroutine(StopDashing());
        }
        anim.SetBool("IsDashing", isDash);
        if (isDash)
        {
            rb.velocity = dashDir.normalized * dashVelocity;
            return;
        }
        if (IsGrounded())
        {
            canDash = true;
        }
    }
    private void Flip()
    {
        facingright = !facingright;
        transform.Rotate(0, 180, 0);

    }
    private void Animation_Update()
    {

        MovementState state;
       

        if (dirx > 0 )
        {
            state = MovementState.Walk;
        }
        else if (dirx < 0 )
        {
            state = MovementState.Walk;

        }
        else
        {
            state = MovementState.Idle;
        }
        if (rb.velocity.y > .1f)
        {
            state = MovementState.Jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.Fall;
        }
        anim.SetInteger("State", (int)state);
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);

        }
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .2f, JumpGround);
    }
    private void fall()
    {
        if (rb.velocity.y < -.1f)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1f) * Time.deltaTime;
        }

        else if (rb.velocity.y > .1f && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1f) * Time.deltaTime;
        }
    }
    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(dashTime);
        trailRenderer.emitting = false;
        isDash=false;
    }

}