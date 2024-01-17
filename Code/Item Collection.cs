using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollection : MonoBehaviour
{
    public float HP = 0;
    [SerializeField] public Text HealthPotions;
    AudioManger audioManger;

    private void Awake()
    {
        audioManger = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManger>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HealthPotions"))
        {
            audioManger.PlaySFX(audioManger.heal);
            Destroy(collision.gameObject);
            HP++;
            HealthPotions.text = ("X " + HP);
        }
    }
    
}
