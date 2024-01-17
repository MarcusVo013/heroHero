using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private static bool IsPause = false;
    [SerializeField] private GameObject PauseMenuUI;
    [SerializeField] private GameObject HealthBar;
    [SerializeField] private string LoadMenuScene = "Menu";
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] Shoot shoot;
    [SerializeField] HealthSystem healthSystem;

    void Update()
    {
        MenuPause();
    }
    public void MenuPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        shoot.enabled = true;
        playerMovement.enabled = true;
         PauseMenuUI.SetActive(false);
        HealthBar.SetActive(true);
        Time.timeScale = 1f;
        IsPause = false;
    }
    private void Pause()
    {
        shoot.enabled = false;
        playerMovement.enabled = false;
        PauseMenuUI.SetActive(true);
        HealthBar.SetActive(false);
        Time.timeScale = 0f;
        IsPause = true;
    }
    //public void SaveGame()
    //{
    //    //SaveSystem.SavePlayer(healthSystem);
    //    //PlayerPrefs.SetInt("HealthSystem", healthSystem.currentHealth);
    //    //PlayerPrefs.SetFloat("PlayerMovement", playerMovement.PositionX);
    //    //PlayerPrefs.SetFloat("PlayerMovement", playerMovement.PositionY);
    //}
    //public void LoadGame()
    //{
    //    ////healthSystem.currentHealth = PlayerPrefs.GetInt("HealthSystem");
    //    ////playerMovement.PositionX = PlayerPrefs.GetFloat("PlayerMovement");
    //    ////playerMovement.PositionY = PlayerPrefs.GetFloat("PlayerMovement");
    //    //PlayerData data = SaveSystem.LoadPlayer();
    //    //healthSystem.currentHealth = data.health;
    //    //healthSystem.potion = data.Potion;
    //    //Vector3 postion;
    //    //postion.x = data.position[0];
    //    //postion.y = data.position[1];
    //    //postion.z = data.position[2];
    //    //transform.position = postion;
    //}
    public void LoadMenu()
    {
        Resume();
        SceneManager.LoadScene("Menu");
    }
    public void Quit()
    {
        Application.Quit();
    }

}
