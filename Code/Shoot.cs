using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform ShootingPoint;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform PushPoint;
    [SerializeField] private GameObject PushBall;
    private Animator anim;
    [SerializeField] private float attackSpeed = 1.0f;
    [SerializeField] private float attackSpeedPush = 5f;
    private float lastAttackTime = 0.0f;
    public GameObject objectToActivate;
    public float activationDuration = 2f; // Duration in seconds
    public float delayBetweenActivations = 1f; // Delay in seconds
    AudioManger audioManger;
    private float activationStartTime;
    private bool canActivate = true;

    private void Awake()
    {
        audioManger = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManger>();
    }
    private void Start()
    {
        
        anim = GetComponent<Animator>();
    }
   
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && CanAttack())
        {
            
            Instantiate(Bullet, ShootingPoint.position,transform.rotation);
            anim.SetTrigger("Shoot");
            lastAttackTime = Time.time;
        }
        if (Input.GetMouseButtonDown(1) && canActivate)
        {
            audioManger.PlaySFX(audioManger.push);
            anim.SetTrigger("push");
            StartCoroutine(ActivateWithDelay());
        }
    }
    private System.Collections.IEnumerator ActivateWithDelay()
    {
        canActivate = false;
        activationStartTime = Time.time;
        objectToActivate.SetActive(true);

        float elapsedTime = 0f;
        while (elapsedTime < activationDuration)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        objectToActivate.SetActive(false);
        yield return new WaitForSeconds(delayBetweenActivations);

        canActivate = true;
    }

    public bool CanAttack()
    {
        float currentTime = Time.time;
        float elapsedTime = currentTime - lastAttackTime;
        return elapsedTime >= attackSpeed;
    }
    public bool CanAttackPush()
    {
        float currentTime = Time.time;
        float elapsedTime = currentTime - lastAttackTime;
        return elapsedTime >= attackSpeedPush;
    }

}
