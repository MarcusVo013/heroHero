using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossDead : MonoBehaviour
{
    private BoxCollider2D box;
    private Rigidbody2D rb;
    private Animator anim;
    private bool died;
    AudioManger audioManger;
    [SerializeField] GameObject gameObject;

    private void Awake()
    {
        audioManger = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManger>();
    }
    private void Start()
    {

        box = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        died = false;
    }
    public void Die()
    {
        audioManger.PlaySFX(audioManger.death);
        rb.velocity = Vector3.zero;
        anim.SetTrigger("Dead");
        died = true;
        Invoke(nameof(Ondead),1f);
        if (died) { return; }
    }
    private void Ondead()
    {

        Destroy(gameObject);
    }
}
