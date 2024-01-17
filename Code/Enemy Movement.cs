using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform[] patrolPoints;
    public Transform returnPoint;
    public float detectionRange = 5f;
    public float chaseRange = 10f;
    public float moveSpeed = 2f;
    public float returnSpeed = 3f;
    public string playerTag = "Player";
    public float patrolPauseTime = 1f;

    public Animator animator;
    public string walkAnimationTrigger = "Walk";
    public string idleAnimationTrigger = "Idle";

    private Transform target;
    private int currentPatrolPointIndex;
    private bool isMovingToNextPatrolPoint;
    private bool isReturning;
    private float patrolPauseTimer;
    private bool isFacingRight = true;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    private void Start()
    {
        currentPatrolPointIndex = 0;
        isMovingToNextPatrolPoint = true;
        isReturning = false;
        MoveToNextPatrolPoint();
    }

    private void FixedUpdate()
    {
        if (!isReturning && target == null)
        {
            if (isMovingToNextPatrolPoint)
            {
                MoveToNextPatrolPoint();
            }
            else
            {
                patrolPauseTimer -= Time.deltaTime;
                if (patrolPauseTimer <= 0f)
                {
                    isMovingToNextPatrolPoint = true;
                    MoveToNextPatrolPoint();
                }
            }
        }
        else if (!isReturning && target != null)
        {
            float distance = Vector2.Distance(transform.position, target.position);
            if (distance > chaseRange)
            {
                target = null;
                isReturning = true;
                animator.SetTrigger(idleAnimationTrigger);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                animator.SetTrigger(walkAnimationTrigger);
                Flip(target.position.x - transform.position.x);
            }
        }
        else if (isReturning)
        {
            transform.position = Vector3.MoveTowards(transform.position, returnPoint.position, returnSpeed * Time.deltaTime);
            float distanceToReturnPoint = Vector2.Distance(transform.position, returnPoint.position);
            if (distanceToReturnPoint < 0.1f)
            {
                isReturning = false;
                isMovingToNextPatrolPoint = true;
                patrolPauseTimer = patrolPauseTime;
                animator.SetTrigger(idleAnimationTrigger);
            }
        }

        if (!isMovingToNextPatrolPoint || target != null || isReturning)
        {
            return;
        }

        // Check for player within the detection range
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRange, LayerMask.GetMask(playerTag));
        if (colliders.Length > 0)
        {
            target = colliders[0].transform;
            isMovingToNextPatrolPoint = false;
            patrolPauseTimer = patrolPauseTime;
            animator.SetTrigger(idleAnimationTrigger);
        }
        else
        {
            float distanceToPatrolPoint = Vector2.Distance(transform.position, patrolPoints[currentPatrolPointIndex].position);
            if (distanceToPatrolPoint < 0.1f)
            {
                isMovingToNextPatrolPoint = true;
                MoveToNextPatrolPoint();
            }
        }
    }

    private void MoveToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0)
        {
            return;
        }

        target = patrolPoints[currentPatrolPointIndex];
        currentPatrolPointIndex = (currentPatrolPointIndex + 1) % patrolPoints.Length;
        animator.SetTrigger(walkAnimationTrigger);
        Flip(target.position.x - transform.position.x);
    }

    private void Flip(float direction)
    {
        if ((direction < 0 && isFacingRight) || (direction > 0 && !isFacingRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}