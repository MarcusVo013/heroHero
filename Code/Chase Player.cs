using Unity.VisualScripting;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float moveSpeed = 3f;
    private bool facingright = true;
    private Transform target;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        target = pointA;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            if (target == pointA)
            {
                target = pointB;
                Flip();
            }
            else
            {
                target = pointA;
                Flip();
            }
        }
    }
    private void Flip()
    {
        facingright = !facingright;
        transform.Rotate(0, 180, 0);

    }
    private void UpdateAnimation()
    {
        if (target.position.x > transform.position.x)
        {
            animator.SetTrigger("Walk");
        }
        else if (target.position.x < transform.position.x)
        {
            animator.SetTrigger("Walk");
        }
    }
}