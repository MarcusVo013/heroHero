using UnityEngine;

public class PatrollingWallToWall : MonoBehaviour
{
    [SerializeField] private float MovementSpeed = 3;
    [SerializeField] private bool bIsGoingRight = true;
    [SerializeField] private float mRaycastingDistance = 1f;
    private Rigidbody2D rb;
    private Animator anim;
    private bool facingright = true;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facingright = bIsGoingRight;
        
    }


    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(MovementSpeed, rb.velocity.y);
    }
    private void Animation()
    {
        if(rb.velocity.x > 0)
        {
            anim.SetTrigger("Walk");
        }
        else if (rb.velocity.x < 0)
        {
            anim.SetTrigger("Walk");
        }
        else { anim.SetTrigger("Idle"); }
    }
    private void Flip()
    {
        if(facingright)
        {
            transform.Rotate(0, 180, 0);
        }
        else
        {
            transform.Rotate(0, 180, 0);
        } 
    }
    private void CheckForWalls()
    {
        
    }
}