using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public HealthSystem healthSystem;
    [SerializeField]private int Damage = 10;
    AudioManger audioManger;
    private void Awake()
    {
        audioManger = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManger>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioManger.PlaySFX(audioManger.swordSound);
        HealthSystem healthSystem = collision.GetComponent<HealthSystem>();
        if (healthSystem != null)
        {
            healthSystem.TakeDame(Damage);
        }
    }
}