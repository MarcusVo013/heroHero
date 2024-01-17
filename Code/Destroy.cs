using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public void DestroyObjectNow()
    {
        Destroy(gameObject);
    }
    public void GameOver()
    {
        Time.timeScale = 0.0f;
    }
    public void DeactivateObject()
    {
        gameObject.SetActive(false);
    }
}
