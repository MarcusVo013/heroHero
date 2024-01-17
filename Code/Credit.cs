using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{
    public float changetime = 6;
    public string scenename;

    // Update is called once per frame
    void Update()
    {

        ChangeScene();
    }
    public void ChangeScene()
    {
        changetime -= Time.deltaTime;
        if (changetime <= 0 || Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(scenename);
        }
    }
}
