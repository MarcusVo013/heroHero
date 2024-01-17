using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] GameObject hero;
    [SerializeField] GameObject Slider;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            hero.SetActive(true);
            Slider.SetActive(false);
            Invoke(nameof(OnDestroyNow), 1f);
            
        }
    }
    private void OnDestroyNow()
    {
        Destroy(gameObject);
    }
}
