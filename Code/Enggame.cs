using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enggame : MonoBehaviour
{
    public string sceneToLoad;

    private void OnDestroy()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneToLoad);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the destroyed object is no longer present in the new scene
        GameObject destroyedObject = GameObject.Find(gameObject.name);
        if (destroyedObject == null)
        {
            // Scene has finished loading and the object is destroyed, so perform scene-specific actions here
            // You can add your desired logic, such as additional initialization, spawning new objects, etc.

            // Remove the event handler to avoid multiple subscriptions
            Invoke(nameof(Load),3f);
        }
    }
    private void Load()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
