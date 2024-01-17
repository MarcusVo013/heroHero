using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public float changetime = 3;
    public string scenename;

    // Update is called once per frame
    void Update()
    {

        ChangeScene();
    }
    public void ChangeScene()
    {
        changetime -= Time.deltaTime;
        if (changetime <= 0)
        {
            SceneManager.LoadScene(scenename);
        }
    }
}
