using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GateBlock : MonoBehaviour
{
    [SerializeField] GameObject go;
    [SerializeField] GameObject go1;
    [SerializeField] GameObject go2;
    [SerializeField] GameObject go3;
    [SerializeField] GameObject go4;
    [SerializeField] private string Object = "Player";
    AudioManger audioManger;
    private void Awake()
    {
        audioManger = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManger>();
    }
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameObject.FindGameObjectWithTag(Object))
        {
            audioManger.PlaySFX(audioManger.ampush);
            go.SetActive(true);
            go1.SetActive(true);
            go2.SetActive(true);
            go3.SetActive(true);
            go4.SetActive(true);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
       
    }
}
