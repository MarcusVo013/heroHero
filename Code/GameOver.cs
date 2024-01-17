using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject GameOverMenu;

    private void OnEnable()
    {
        Dead.OnPlayerDeath += EnableGameOverMenu;
    }
    private void OnDisable()
    {
        Dead.OnPlayerDeath -= EnableGameOverMenu;
    }

    private void EnableGameOverMenu()
    {
       GameOverMenu.SetActive(true);
    }
}
