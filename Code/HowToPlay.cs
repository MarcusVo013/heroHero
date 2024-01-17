using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    [SerializeField] private GameObject HowToPlayMenu;
    private bool showHTP = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if(!showHTP) { Open(); }
            else { Close(); }
        }
    }

    public void Open()
    {
        showHTP = true;
        HowToPlayMenu.SetActive(true);
    }
    public void Close()
    {
        showHTP =false;
        HowToPlayMenu.SetActive(false);
    }
}
