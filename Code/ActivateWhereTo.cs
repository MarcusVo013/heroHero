using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWhereTo : MonoBehaviour
{
    [SerializeField] GameObject whereto;
    [SerializeField] GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.SetActive(false);
            whereto.SetActive(true);
            Invoke(nameof(StopWhereTo), 4f);
        }
    }
    void StopWhereTo()
    {
        player.SetActive(true) ;
        whereto.SetActive(false);
        Destroy(gameObject);
    }
}
